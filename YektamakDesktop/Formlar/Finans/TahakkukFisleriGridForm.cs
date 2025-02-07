using Models;
using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Finans
{
    public partial class TahakkukFisleriGridForm : Form, IForm
    {
        private static TahakkukFisleriGridForm _tahakkukFisleriGridForm;
        public static TahakkukFisleriGridForm tahakkukFisleriGridForm
        {
            get
            {
                if (_tahakkukFisleriGridForm == null)
                {
                    _tahakkukFisleriGridForm = new TahakkukFisleriGridForm();
                    GlobalData.Yetki(ref _tahakkukFisleriGridForm);
                }
                return _tahakkukFisleriGridForm;
            }
            set
            {
                _tahakkukFisleriGridForm = value;
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
        private DataSet _dataSet;
        public DataSet dataSet
        {
            get
            {
                if (_dataSet == null)
                    _dataSet = new DataSet();
                return _dataSet;
            }
            set
            {
                _dataSet = value;
            }
        }
        public TahakkukFisleriGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>()
            {

            };
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
        /// Silme ve güncelleme butonlarının görünürlüğünü ayarlar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (_dataSet == null || e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGridView.ColumnCount - 2 && e.RowIndex >= 0 && e.RowIndex < _dataSet.Tables[0].Rows.Count)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                float r1 = (float)Properties.Resources.update_icon.Width / Properties.Resources.update_icon.Height;
                float r2 = (float)e.CellBounds.Width / e.CellBounds.Height;
                int w = e.CellBounds.Width;
                int h = e.CellBounds.Height;
                if (r1 > r2)
                {
                    w = e.CellBounds.Width;
                    h = (int)(w / r1);
                }
                else if (r1 < r2)
                {
                    h = e.CellBounds.Height;
                    w = (int)(r1 * h);
                }
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.update_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            else if (e.ColumnIndex == dataGridView.ColumnCount - 1 && e.RowIndex >= 0 && e.RowIndex < _dataSet.Tables[0].Rows.Count)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                float r1 = (float)Properties.Resources.delete_icon.Width / Properties.Resources.delete_icon.Height;
                float r2 = (float)e.CellBounds.Width / e.CellBounds.Height;
                int w = e.CellBounds.Width;
                int h = e.CellBounds.Height;
                if (r1 > r2)
                {
                    w = e.CellBounds.Width;
                    h = (int)(w / r1);
                }
                else if (r1 < r2)
                {
                    h = e.CellBounds.Height;
                    w = (int)(r1 * h);
                }
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.delete_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        /// <summary>
        /// Grid'de seçilen cari kartı güncellemek için CariKartKayit formunu açar ya da silme işlemini yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex == -1) return;
            dataGridView.Rows[e.RowIndex].Selected = true;
            if (_dataSet == null || e.RowIndex < 0) return;
            if (e.RowIndex >= _dataSet.Tables[0].Rows.Count) return;
            if (e.ColumnIndex == dataGridView.ColumnCount - 2 || e.ColumnIndex == dataGridView.ColumnCount - 1)
            {
                if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
                    return;
                TahakkukFisi tahakkukFisi = new TahakkukFisi();
                tahakkukFisi.tahakkukFisId = int.Parse(dataGridView.Rows[e.RowIndex].Cells["tahakkukFisId"].Value.ToString());
                tahakkukFisi.cari = new CariKart();
                tahakkukFisi.cari.cariKartId = int.Parse(dataGridView.Rows[e.RowIndex].Cells["cariKartId"].Value.ToString());
                tahakkukFisi.cari.cariAdi = dataGridView.Rows[e.RowIndex].Cells["cariAdi"].Value.ToString();
                tahakkukFisi.tutar = new Tutar();
                tahakkukFisi.tutar.tutar = float.Parse(dataGridView.Rows[e.RowIndex].Cells["tutar"].Value.ToString());
                tahakkukFisi.tutar.dovizCinsi.id = int.Parse(dataGridView.Rows[e.RowIndex].Cells["dovizId"].Value.ToString());
                tahakkukFisi.tahakkukTarihi = DateTime.Parse(dataGridView.Rows[e.RowIndex].Cells["tahakkukTarihi"].Value.ToString());
                tahakkukFisi.vadeTarihi = DateTime.Parse(dataGridView.Rows[e.RowIndex].Cells["vadeTarihi"].Value.ToString());
                tahakkukFisi.aciklama = dataGridView.Rows[e.RowIndex].Cells["aciklama"].Value.ToString();
                if (e.ColumnIndex == dataGridView.ColumnCount - 2)//Update
                {
                    TahakkukFisiKayitFormu tahakkukFisiKayitFormu = TahakkukFisiKayitFormu.tahakkukFisiKayitFormu;
                    if(tahakkukFisiKayitFormu != null)
                    {
                        tahakkukFisiKayitFormu.Show();
                        tahakkukFisiKayitFormu.UpdateMode(tahakkukFisi);
                    }
                }
                else if (e.ColumnIndex == dataGridView.ColumnCount - 1)//Delete
                {
                    DialogResult dialogResult = MessageBox.Show("Kredi kartını silmek istediğinize emin misiniz?", "Kredi Kartı Silme", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    string result = await WebMethods.DeleteTahakkukFisi(tahakkukFisi);
                    //    if (result.Substring(0, 5) != "error")
                    //    {
                    //        dataGridView.Rows.RemoveAt(e.RowIndex);
                    //        MessageBox.Show("Kredi kartı başarıyla silindi.");
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(result);
                    //    }
                    //}
                }
            }
        }

        private void buttonTahakkukFisiEkle_Click(object sender, EventArgs e)
        {
            TahakkukFisiKayitFormu tahakkukFisiKayitFormu = TahakkukFisiKayitFormu.tahakkukFisiKayitFormu;
            if(tahakkukFisiKayitFormu != null)
            {
                tahakkukFisiKayitFormu.Show();
                tahakkukFisiKayitFormu.SaveMode();
            }
        }

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _tahakkukFisleriGridForm = null;
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            TahakkukFisi tahakkukFisi = new TahakkukFisi();
            tahakkukFisi.cari = new CariKart();
            GetDataSet(tahakkukFisi);
        }
        public async Task GetDataSet(TahakkukFisi tahakkukFisi)
        {

            //var httpTask = WebMethods.GetFilteredTahakkukFisi(tahakkukFisi);
            //string httpResult = await httpTask;
            //byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            //string json = Encoding.UTF8.GetString(bytes);
            //dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            //dataGridViewTahakkukFisleri.Rows.Clear();
            //if (dataSet.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dataSet.Tables[0].Rows)
            //    {
            //        dataGridViewTahakkukFisleri.Rows.Add();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["tahakkukFisId"].Value = dr["TahakkukFisId"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["cariKartId"].Value = dr["CariKartId"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["cariAdi"].Value = dr["CariAdi"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["tutar"].Value = dr["Tutar"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["dovizId"].Value = dr["dovizId"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["DovizSembol"].Value = dr["DovizSembol"].ToString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["tahakkukTarihi"].Value = DateTime.Parse(dr["TahakkukTarihi"].ToString()).ToShortDateString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["VadeTarihi"].Value = DateTime.Parse(dr["VadeTarihi"].ToString()).ToShortDateString();
            //        dataGridViewTahakkukFisleri.Rows[dataGridViewTahakkukFisleri.Rows.Count - 1].Cells["aciklama"].Value = dr["Aciklama"].ToString();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Görüntülenecek kayıt bulunamadı");
            //}
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            TahakkukFisi tahakkukFisi = new TahakkukFisi();
            tahakkukFisi.cari = new CariKart();
            tahakkukFisi.cari.cariAdi = textBoxFiltreKartSahibi.Text;
            GetDataSet(tahakkukFisi);
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
