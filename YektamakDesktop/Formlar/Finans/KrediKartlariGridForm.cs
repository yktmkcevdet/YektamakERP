using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class KrediKartlariGridForm : Form, IForm
    {
        private static KrediKartlariGridForm _krediKartlariGridForm;
        public static KrediKartlariGridForm krediKartlariGridForm
        {
            get
            {
                if (_krediKartlariGridForm == null)
                {
                    _krediKartlariGridForm = new KrediKartlariGridForm();
                    GlobalData.Yetki(ref _krediKartlariGridForm);
                }
                return _krediKartlariGridForm;
            }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataSet _dataSet;
        public DataSet dataSet { get => _dataSet; set => _dataSet = value; }
        public KrediKartlariGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
        }
        #region mouseDrag
        bool mouseDown;
        private Point offset;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag
        
        /// <summary>
        /// Grid'de seçilen cari kartı güncellemek için CariKartKayit formunu açar ya da silme işlemini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dataGridViewCariKartlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGridViewKrediKarti.Rows[e.RowIndex].Selected = true;
            if (_dataSet == null || e.RowIndex < 0) return;
            if (e.RowIndex >= _dataSet.Tables[0].Rows.Count) return;
            if (e.ColumnIndex == dataGridViewKrediKarti.ColumnCount - 2 || e.ColumnIndex == dataGridViewKrediKarti.ColumnCount - 1)
            {

                if (dataGridViewKrediKarti.Rows[e.RowIndex].Cells[0].Value == null)
                    return;

                KrediKarti krediKarti = new KrediKarti();
                krediKarti.krediKartiId = int.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[0].Value.ToString());
                krediKarti.kartSahibi = dataGridViewKrediKarti.Rows[e.RowIndex].Cells[1].Value.ToString();
                krediKarti.kartNumarasi = dataGridViewKrediKarti.Rows[e.RowIndex].Cells[2].Value.ToString();
                krediKarti.bagliHesap = new BankaHesabi();
                krediKarti.bagliHesap.hesapId = int.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[3].Value.ToString());
                krediKarti.dovizCinsi = new DovizCinsi();
                krediKarti.dovizCinsi.id = int.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[5].Value.ToString());
                krediKarti.hesapKesimTarihi = DateTime.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[7].Value.ToString());
                krediKarti.sonOdemeTarihi = DateTime.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[8].Value.ToString());
                krediKarti.kartLimiti = float.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[9].Value.ToString());
                krediKarti.guncelKartLimiti = float.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[10].Value.ToString());
                krediKarti.ekstreBorcu = float.Parse(dataGridViewKrediKarti.Rows[e.RowIndex].Cells[11].Value.ToString());

                if (e.ColumnIndex == dataGridViewKrediKarti.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)
                {
                    KrediKartiKayitFormu krediKartiKayitFormu = KrediKartiKayitFormu.krediKartiKayitFormu;
                    if(krediKartiKayitFormu != null) 
                    {
                        krediKartiKayitFormu.Show();
                        krediKartiKayitFormu.UpdateMode(krediKarti);
                    }
                }
                else if (e.ColumnIndex == dataGridViewKrediKarti.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    DialogResult dialogResult = MessageBox.Show("Kredi kartını silmek istediğinize emin misiniz?", "Kredi Kartı Silme", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string result = await WebMethods.DeleteKrediKarti(krediKarti);
                        if (!result.Contains("error",StringComparison.OrdinalIgnoreCase))
                        {
                            dataGridViewKrediKarti.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Kredi kartı başarıyla silindi.");
                        }
                        else
                        {
                            MessageBox.Show(result);
                        }
                    }
                }
            }
        }
        public async void buttonFiltre_Click(object sender, EventArgs e)
        {
            KrediKarti krediKarti = new KrediKarti();
            krediKarti.kartSahibi = textBoxFiltreKartSahibi.Text;
            string jsonString = await WebMethods.GetFilteredKrediKarti(krediKarti);
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            dataSet = jsonConverter.JsonStringToDataSet(jsonString);
            //GlobalData.FillDataGrid(dataSet.Tables[0],dataGridViewKrediKarti,krediKarti);
        }
        private async void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            string jsonString = await WebMethods.GetFilteredKrediKarti(new KrediKarti());
            dataSet = jsonConverter.JsonStringToDataSet(jsonString);
            //GlobalData.FillDataGrid(dataSet.Tables[0],dataGridViewKrediKarti, new KrediKarti());
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _krediKartlariGridForm = null;
        }

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void buttonKrediKartiEkle_Click(object sender, EventArgs e)
        {
            KrediKartiKayitFormu krediKartiKayitFormu = KrediKartiKayitFormu.krediKartiKayitFormu;
            if(krediKartiKayitFormu != null)
            {
                krediKartiKayitFormu.Show();
                krediKartiKayitFormu.SaveMode();
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
