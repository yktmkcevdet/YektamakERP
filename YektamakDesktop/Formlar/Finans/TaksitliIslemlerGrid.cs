using YektamakDesktop.CustomControls;
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
    public partial class TaksitliOdemeGrid : Form, IForm
    {
        private static TaksitliOdemeGrid _taksitliOdemeGrid;
        public static TaksitliOdemeGrid taksitliOdemeGrid
        {
            get
            {
                if (_taksitliOdemeGrid == null)
                {
                    _taksitliOdemeGrid = new TaksitliOdemeGrid();
                    GlobalData.Yetki(ref  _taksitliOdemeGrid);
                }
                return _taksitliOdemeGrid;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        private DataSet _dataSet;
        private CustomTextBox _selectedCustomTextBox;
        public TaksitliOdemeGrid()
        {
            InitializeComponent();
            controlsToDisable = new List<Control>
            {
                rButtonFiltre,
                rButtonKapat,
                rButtonTemizle,
                customComboListBoxFilterCariId,
                customComboListBoxFilterDovizId,
                customTextBoxFilterBaslangicIslemTarihi,
                customTextBoxFilterBitisIslemTarihi
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
            //DataGridView dataGridView = (DataGridView)sender;
            //if (e.RowIndex == -1) return;
            //dataGridView.Rows[e.RowIndex].Selected = true;
            //if (_dataSet == null || e.RowIndex < 0) return;
            //if (e.RowIndex >= _dataSet.Tables[0].Rows.Count) return;
            //if (e.ColumnIndex == dataGridView.ColumnCount - 2 || e.ColumnIndex == dataGridView.ColumnCount - 1)
            //{
            //    if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
            //        return;
            //    TaksitliOdeme taksitliOdeme = new TaksitliOdeme();
            //    taksitliOdeme.taksitliOdemeId = int.Parse(dataGridView.Rows[e.RowIndex].Cells["taksitliOdemeId"].Value.ToString());
            //    taksitliOdeme.odemeTanimi = dataGridView.Rows[e.RowIndex].Cells["odemeTanimi"].Value.ToString();
            //    taksitliOdeme.toplamTutar = new Tutar();
            //    taksitliOdeme.toplamTutar.tutar = float.Parse(dataGridView.Rows[e.RowIndex].Cells["toplamTutar"].Value.ToString());
            //    taksitliOdeme.toplamTutar.dovizCinsi.id = int.Parse(dataGridView.Rows[e.RowIndex].Cells["dovizId"].Value.ToString());
            //    taksitliOdeme.cari = new CariKart();
            //    taksitliOdeme.cari.cariKartId = int.Parse(dataGridView.Rows[e.RowIndex].Cells["cariId"].Value.ToString());
            //    taksitliOdeme.islemTarihi = DateTime.Parse(dataGridView.Rows[e.RowIndex].Cells["islemTarihi"].Value.ToString());
            //    string httpResult = await WebMethods.GetTaksitOdemesiByTaksitliOdemeId(taksitliOdeme.taksitliOdemeId);
            //    byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            //    string data = Encoding.UTF8.GetString(bytes);
            //    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(data);
            //    List<TaksitOdemesi> taksitOdemesiList = new List<TaksitOdemesi>();
            //    foreach (DataRow dr in dataSet.Tables[0].Rows)
            //    {
            //        TaksitOdemesi taksitOdemesi = new TaksitOdemesi();
            //        taksitOdemesi.taksitNo = Convert.ToInt16(dr["taksitNo"].ToString());
            //        taksitOdemesi.tutar = new Tutar();
            //        taksitOdemesi.tutar.tutar = float.Parse(dr["tutar"].ToString());
            //        taksitOdemesi.tutar.dovizCinsi.id = Convert.ToInt16(dr["dovizId"].ToString());
            //        taksitOdemesi.taksitOdemesiId = Convert.ToInt16(dr["taksitOdemesiId"].ToString());
            //        taksitOdemesi.taksitliOdemeId = Convert.ToInt16(dr["taksitliOdemeId"].ToString());
            //        taksitOdemesi.odendiMi = bool.TryParse(dr["odendiMi"].ToString(), out bool odendiMi) ? odendiMi : false;
            //        taksitOdemesi.sonOdemeTarihi = DateTime.Parse(dr["sonOdemeTarihi"].ToString());
            //        taksitOdemesi.odemeGerceklesenTarih = DateTime.TryParse(dr["odemeGerceklesenTarih"].ToString(), out DateTime result) ? result : DateTime.MinValue;
            //        taksitOdemesiList.Add(taksitOdemesi);
            //    }
            //    if (e.ColumnIndex == dataGridView.ColumnCount - 2)//Update
            //    {
            //        TaksitliOdemeKayitFormu taksitliOdemeKayitFormu = TaksitliOdemeKayitFormu.taksitliOdemeKayitFormu;
            //        if(taksitliOdemeKayitFormu != null)
            //        {
            //            taksitliOdemeKayitFormu.Show();
            //            taksitliOdemeKayitFormu.UpdateMode(taksitliOdeme, taksitOdemesiList);
            //        }
            //    }
            //    else if (e.ColumnIndex == dataGridView.ColumnCount - 1)//Delete
            //    {
            //        DialogResult dialogResult = MessageBox.Show("Taksiti ödeme kaydını silmek istediğinize emin misiniz?", "Taksitli Ödeme Kaydı Silme", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            string result = await WebMethods.DeleteTaksitliOdeme(taksitliOdeme.taksitliOdemeId);
            //            if (!result.Substring(0, 5).Equals("error", StringComparison.OrdinalIgnoreCase))
            //            {
            //                dataGridView.Rows.RemoveAt(e.RowIndex);
            //                MessageBox.Show("Taksitli Ödeme Kaydı başarıyla silindi.");
            //            }
            //            else
            //            {
            //                MessageBox.Show(result);
            //            }
            //        }
            //    }
            //}
        }

        private async void rButtonfiltre_Click(object sender, EventArgs e)
        {
            //dataGridViewTaksitliOdeme.Rows.Clear();
            //TaksitliOdemeFiltre taksitliOdemeFiltre = new TaksitliOdemeFiltre();
            //taksitliOdemeFiltre.cari = new CariKart();
            //taksitliOdemeFiltre.cari.cariKartId = customComboListBoxFilterCariId.selectedDataRowId;
            //taksitliOdemeFiltre.baslangicIslemTarihi = DateTime.TryParse(customTextBoxFilterBaslangicIslemTarihi.TextCustom.ToString(), out DateTime baslangicIslemTarihi) ? baslangicIslemTarihi : null;
            //taksitliOdemeFiltre.bitisIslemTarihi = DateTime.TryParse(customTextBoxFilterBitisIslemTarihi.TextCustom.ToString(), out DateTime bitisIslemTarihi) ? bitisIslemTarihi : null;
            //taksitliOdemeFiltre.toplamTutar = new Tutar();
            //taksitliOdemeFiltre.toplamTutar.dovizCinsi.id = customComboListBoxFilterDovizId.selectedDataRowId;
            //string httpResult = await WebMethods.GetFilteredTaksitliOdeme(taksitliOdemeFiltre);
            //byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            //string data = Encoding.UTF8.GetString(bytes);
            //_dataSet = JsonConvert.DeserializeObject<DataSet>(data);
            //foreach (DataRow dr in _dataSet.Tables[0].Rows)
            //{
            //    dataGridViewTaksitliOdeme.Rows.Add();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["TaksitliOdemeId"].Value = dr["TaksitliOdemeId"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["CariId"].Value = dr["CariId"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["CariAdi"].Value = dr["CariAdi"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["ToplamTutar"].Value = dr["ToplamTutar"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["DovizId"].Value = dr["DovizId"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["DovizSembol"].Value = dr["DovizSembol"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["IslemTarihi"].Value = DateTime.Parse(dr["IslemTarihi"].ToString()).ToShortDateString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["OdemeTanimi"].Value = dr["OdemeTanimi"].ToString();
            //    dataGridViewTaksitliOdeme.Rows[dataGridViewTaksitliOdeme.Rows.Count - 1].Cells["taksitAdedi"].Value = dr["taksitAdedi"].ToString();
            //}
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _taksitliOdemeGrid = null;
        }

        private void rButtonKapat_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void TaksitliOdemeGrid_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            CariKart cariKart = new CariKart();
            string httpResult = WebMethods.GetFilteredCariKartlar(cariKart);
            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(httpResult);
            string data = Encoding.UTF8.GetString(bytes);
            DataSet cariKartlar = JsonConvert.DeserializeObject<DataSet>(data);
            foreach (DataRow dr in cariKartlar.Tables[0].Rows)
            {
                customComboListBoxFilterCariId.AddDataRow(int.Parse(dr["cariId"].ToString()), dr["cariAdi"].ToString());
            }
            //foreach (DovizCinsi dc in GlobalData.dovizList)
            //{
            //    customComboListBoxFilterDovizId.AddDataRow(dc.id, dc.sembol);
            //}
            customComboListBoxFilterDovizId.SelectDataRowId(1);
            Opacity = 1;
        }
        private void SelectCustomTextBox(object sender, EventArgs e)
        {
            _selectedCustomTextBox = (CustomTextBox)sender;
            monthCalendar1.Visible = true;
            monthCalendar1.Location = new Point(_selectedCustomTextBox.Location.X - 107, _selectedCustomTextBox.Location.Y + _selectedCustomTextBox.Height - 8);
            monthCalendar1.BringToFront();
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            _selectedCustomTextBox.TextCustom = e.Start.ToShortDateString();
            monthCalendar1.Visible = false;
        }

        private void buttonKrediKartiEkle_Click(object sender, EventArgs e)
        {
            TaksitliOdemeKayitFormu taksitliOdemeKayitFormu = TaksitliOdemeKayitFormu.taksitliOdemeKayitFormu;
            if(taksitliOdemeKayitFormu == null)
            {
                taksitliOdemeKayitFormu.Show();
            }
        }

        private void rButtonTemizle_Click(object sender, EventArgs e)
        {
            customComboListBoxFilterDovizId.SelectDataRowId(-1);
            customComboListBoxFilterCariId.SelectDataRowId(-1);
            customTextBoxFilterBaslangicIslemTarihi.TextCustom = string.Empty;
            customTextBoxFilterBitisIslemTarihi.TextCustom = string.Empty;
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

