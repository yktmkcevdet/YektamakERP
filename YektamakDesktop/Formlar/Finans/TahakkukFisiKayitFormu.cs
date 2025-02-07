using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class TahakkukFisiKayitFormu : Form, IForm
    {
        private static TahakkukFisiKayitFormu _tahakkukFisiKayitFormu;
        public static TahakkukFisiKayitFormu tahakkukFisiKayitFormu
        {
            get
            {
                if (_tahakkukFisiKayitFormu == null)
                {
                    _tahakkukFisiKayitFormu = new TahakkukFisiKayitFormu();
                    GlobalData.Yetki(ref _tahakkukFisiKayitFormu);
                }
                return _tahakkukFisiKayitFormu;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable
        {
            get
            {
                return _controlsToDisable;
            }
            set
            {
                _controlsToDisable = value;
            }
        }
        private bool _activeForm;
        public bool activeForm
        {
            get
            {
                return _activeForm;
            }
            set
            {
                _activeForm = value;
            }
        }
        private TahakkukFisi _tahakkukFisi;
        public TahakkukFisi tahakkukFisi
        {
            get
            {
                return _tahakkukFisi;
            }
            set
            {
                _tahakkukFisi = value;
            }
        }
        private int _tahakkukFisId;
        public TahakkukFisiKayitFormu()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>();
            //foreach (DovizCinsi dovizCinsi in GlobalData.dovizList)
            //{
            //    customComboListBoxDovizId.AddDataRow(dovizCinsi.id, dovizCinsi.sembol);
            //}
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

        public void UpdateMode(TahakkukFisi tahakkukFisiToUpdate)
        {
            tahakkukFisi = tahakkukFisiToUpdate;
            rButtonKaydet.Visible = false;
            _tahakkukFisId = tahakkukFisi.tahakkukFisId;
            textBoxTutar.TextCustom = tahakkukFisi.tutar.tutar.ToString();
            customComboListBoxDovizId.SelectDataRowId(tahakkukFisi.tutar.dovizCinsi.id);
            textBoxTahakkukTarihi.TextCustom = tahakkukFisi.tahakkukTarihi.ToShortDateString();
            textBoxVadeTarihi.TextCustom = tahakkukFisi.vadeTarihi.ToShortDateString();
            textBoxAciklama.Text = tahakkukFisi.aciklama;
        }
        public void SaveMode()
        {
            rButtonGuncelle.Visible = false;
        }
        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _tahakkukFisiKayitFormu = null;
            TahakkukFisleriGridForm tahakkukFisleriGrid = TahakkukFisleriGridForm.tahakkukFisleriGridForm;
            tahakkukFisleriGrid.buttonTumKayitlariGetir_Click(null, null);
        }
        private void TahakkukFisiKayitFormu_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            //foreach (CariKart cariKart in GlobalData.cariKartList)
            //{
            //    customComboListBoxCariKartId.AddDataRow(cariKart.cariKartId, cariKart.cariAdi);
            //}
            if (tahakkukFisi != null)
            {
                customComboListBoxCariKartId.SelectDataRowId(tahakkukFisi.cari.cariKartId);
            }
            this.Opacity = 1;
        }
        private bool CheckFields()
        {
            labelUyariCariAdi.Text = "";
            labelUyariOdemeTarihi.Text = "";
            labelUyariTahakkukTarihi.Text = "";
            labelUyariTutar.Text = "";
            bool returnValue = true;
            if (customComboListBoxCariKartId.selectedDataRowId == -1)
            {
                returnValue = false;
                labelUyariCariAdi.Text = "Cari kart seçimi yapılmalıdır.";
            }
            if (string.IsNullOrWhiteSpace(textBoxTutar.TextCustom))
            {
                returnValue = false;
                labelUyariTutar.Text = "Tutar girilmelidir";
            }

            if (customComboListBoxDovizId.selectedDataRowId == -1)
            {
                returnValue = false;
                labelUyariTutar.Text = "Döviz birimi seçilmelidir";
            }
            if (string.IsNullOrWhiteSpace(textBoxTahakkukTarihi.TextCustom))
            {
                returnValue = false;
                labelUyariTahakkukTarihi.Text = "Tahakkuk tarihi girilmelidir.";
            }
            if (string.IsNullOrWhiteSpace(textBoxVadeTarihi.TextCustom))
            {
                returnValue = false;
                labelUyariOdemeTarihi.Text = "Ödeme tarihi girilmelidir.";
            }
            return returnValue;
        }
        public void GetCurrentData()
        {
            if (CheckFields())
            {
                tahakkukFisi = new TahakkukFisi();
                tahakkukFisi.tahakkukFisId = _tahakkukFisId;
                tahakkukFisi.cari = new CariKart();
                tahakkukFisi.cari.cariKartId = customComboListBoxCariKartId.selectedDataRowId;
                tahakkukFisi.tutar = new Tutar();
                tahakkukFisi.tutar.tutar = float.Parse(textBoxTutar.TextCustom);
                tahakkukFisi.tutar.dovizCinsi.id = customComboListBoxDovizId.selectedDataRowId;
                tahakkukFisi.tahakkukTarihi = DateTime.Parse(textBoxTahakkukTarihi.TextCustom);
                tahakkukFisi.vadeTarihi = DateTime.Parse(textBoxVadeTarihi.TextCustom);
                tahakkukFisi.aciklama = textBoxAciklama.Text;
            }
        }
        private async void rButtonKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            GetCurrentData();
            //var httpTask = WebMethods.SaveTahakkukFisi(tahakkukFisi);
            //string httpResult = await httpTask;
            //if (httpResult.Substring(0, 5) != "error")
            //{
            //    MessageBox.Show("Tahakkuk fişi başarıyla kaydedildi.");
            //    CloseForm();
            //}
            //else
            //{
            //    MessageBox.Show(httpResult);
            //}
        }
        private async void rButtonGuncelle_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                return;
            }
            GetCurrentData();
            //var httpTask = WebMethods.SaveTahakkukFisi(tahakkukFisi);
            //string httpResult = await httpTask;
            //if (httpResult.Substring(0, 5) != "error")
            //{
            //    MessageBox.Show("Tahakkuk fişi başarıyla kaydedildi.");
            //    CloseForm();
            //}
            //else
            //{
            //    MessageBox.Show(httpResult);
            //}
        }
        private void customComboListBoxCariKartId_SelectedIndexChanged(object sender, EventArgs e)
        {
            CariKart cariKart = new();
            cariKart.cariKartId = customComboListBoxCariKartId.selectedDataRowId;
            string httpResult = WebMethods.GetFilteredCariKartlar(cariKart);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string json = Encoding.UTF8.GetString(bytes);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            //int dovizId = GlobalData.dovizList.Find(x => x.id == int.Parse(dataRow["DovizId"].ToString())).id;
            //customComboListBoxDovizId.SelectDataRowId(dovizId);
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
