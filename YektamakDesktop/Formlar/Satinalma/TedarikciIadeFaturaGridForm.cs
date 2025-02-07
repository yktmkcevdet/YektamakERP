using YektamakDesktop.Formlar.Ortak;
using YektamakDesktop.Formlar.Satinalma;
using YektamakDesktop.Formlar.TedarikciIade;
using Models;

using Newtonsoft.Json;
using ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class TedarikciIadeFaturaGridForm : Form, IForm
    {
        private static TedarikciIadeFaturaGridForm _tedarikciIadeFaturaGridForm;
        public static TedarikciIadeFaturaGridForm tedarikciIadeFaturaGridForm
        {
            get
            {
                if (_tedarikciIadeFaturaGridForm == null)
                {
                    _tedarikciIadeFaturaGridForm = new TedarikciIadeFaturaGridForm();
                    GlobalData.Yetki(ref _tedarikciIadeFaturaGridForm);
                }
                return _tedarikciIadeFaturaGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public TedarikciIadeFaturaGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control.Name != "panelHeader")
                {
                    controlsToDisable.Add(control);
                }
            }
        }
        #region MouseDrag
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
        #endregion MouseDrag
        ToolTip buttonFiltreToolTip;
        ToolTip buttonTumKayitlariGetirToolTip;
        /// <summary>
        /// dataSet her zaman grid'le aynı sıralamaya sahip olacak
        /// </summary>
        private DataSet _dataSet;
        public DataSet dataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new DataSet();
                }
                return _dataSet;
            }
        }
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Tedarikçi İade Faturaları Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;

            buttonTumKayitlariGetirToolTip = new ToolTip();
            buttonTumKayitlariGetirToolTip.ToolTipTitle = "Tüm Tedarikçi İade Faturaları";
            buttonTumKayitlariGetirToolTip.SetToolTip(buttonTumKayitlariGetir, "Tüm tedarikçiye iade faturalarını gride listeler.");
            buttonTumKayitlariGetirToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonTumKayitlariGetirToolTip.AutoPopDelay = 20000;

            buttonTumKayitlariGetirToolTip = new ToolTip();
            buttonTumKayitlariGetirToolTip.ToolTipTitle = "Yeni Tedarikçi İade Faturası";
            buttonTumKayitlariGetirToolTip.SetToolTip(buttonTedarikciIadeFaturaEkle, "Yeni bir tedarikçi iade faturası oluşturmak için tıkla.");
            buttonTumKayitlariGetirToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonTumKayitlariGetirToolTip.AutoPopDelay = 20000;

        }
        /// <summary>
        /// Update ve delete işlemi yapacak hücrelerin ikonları grid satırlarına ekler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewTedarikciIadeFatura_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (_dataSet == null || e.RowIndex < 0) return;
            if (e.ColumnIndex == 7 && e.RowIndex >= 0 && e.RowIndex < _dataSet.Tables[0].Rows.Count)
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
            else if (e.ColumnIndex == 8 && e.RowIndex >= 0 && e.RowIndex < _dataSet.Tables[0].Rows.Count)
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
        /// Grid üzerinde update ve delete hücrelerine tıklatıldığında ilgili işlevi gerçekleştirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dataGridViewTedarikciIadeFatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (_dataSet == null || e.RowIndex < 0) return;
            //dataGridViewTedarikciIadeFatura.Rows[e.RowIndex].Selected = true;
            //if (e.RowIndex >= _dataSet.Tables[0].Rows.Count) return;
            //if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
            //{
            //    TedarikciIadeFatura tedarikciIadeFatura = new TedarikciIadeFatura();
            //    tedarikciIadeFatura.tedarikciIadeFaturaId = int.Parse(dataGridViewTedarikciIadeFatura.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    var httpTask = WebMethods.GetFilteredTedarikciIadeFatura(tedarikciIadeFatura);
            //    string result = await httpTask;
            //    if (result.Length > 6 && result.Contains("error"))
            //    {
            //        MessageBox.Show(result);
            //    }
            //    else
            //    {
            //        byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
            //        string json = Encoding.UTF8.GetString(bytes);
            //        DataSet ds = JsonConvert.DeserializeObject<DataSet>(json);
            //        DataRow dr = ds.Tables[0].Rows[0];
            //        tedarikciIadeFatura = new TedarikciIadeFatura();
            //        tedarikciIadeFatura.tedarikciIadeFaturaId = int.Parse(dr["TedarikciIadeFaturaId"].ToString());
            //        tedarikciIadeFatura.projeKod.Id = int.Parse(dr["ProjeKodId"].ToString());
            //        tedarikciIadeFatura.tedarikciIadeFaturaNo = dr["TedarikciIadeFaturaNo"].ToString();
            //        tedarikciIadeFatura.tedarikciIadeFaturaTarihi = DateTime.Parse(dr["TedarikciIadeFaturaTarihi"].ToString());
            //        tedarikciIadeFatura.tedarikciIadeFaturaTutari.tutar = float.Parse(dr["FaturaTutari"].ToString());
            //        tedarikciIadeFatura.tedarikciIadeFaturaTutari.dovizCinsi = new DovizCinsi();
            //        tedarikciIadeFatura.tedarikciIadeFaturaTutari.dovizCinsi.id = int.Parse(dr["DovizBirimId"].ToString());
            //        tedarikciIadeFatura.cariKart.cariKartId = int.Parse(dr["cariKartId"].ToString());
            //        tedarikciIadeFatura.kdv.kdvId = int.Parse(dr["KDVId"].ToString());
            //    }
            //    if (e.ColumnIndex == 7)//Update
            //    {
            //        TedarikciIadeFaturaKayitFormu tedarikciIadeFaturaKayitFormu = TedarikciIadeFaturaKayitFormu.tedarikciIadeFaturaKayitFormu;
            //        if(tedarikciIadeFaturaKayitFormu != null)
            //        {
            //            tedarikciIadeFaturaKayitFormu.UpdateMode(tedarikciIadeFatura);
            //            tedarikciIadeFaturaKayitFormu.Show();
            //        }
            //    }
            //    else if (e.ColumnIndex == 8)//Delete
            //    {
            //        DeleteTedarikciIadeFatura(tedarikciIadeFatura, e.RowIndex);
            //    }
            //}
        }
        /// <summary>
        /// Grid üerinden silinecek kayıt için ilk önce uyarı verir, evete tıklanırsa kaydı veritabanından ve gridden siler.
        /// </summary>
        /// <param name="tedarikciIadeFatura"></param>
        /// <param name="rowId"></param>
        private async Task DeleteTedarikciIadeFatura(TedarikciIadeFatura tedarikciIadeFatura, int rowId)
        {
            //DialogResult dialogResult = MessageBox.Show(string.Format("{0} nolu faturayı silmek istediğinizden emin misiniz", tedarikciIadeFatura.tedarikciIadeFaturaNo), "", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    int tedarikciIadeFaturaId = int.Parse(dataGridViewTedarikciIadeFatura.Rows[rowId].Cells[0].Value.ToString());
            //    await WebMethods.DeleteTedarikciIadeFatura(tedarikciIadeFaturaId);
            //    dataGridViewTedarikciIadeFatura.Rows.RemoveAt(rowId);
            //    int dataSetIndex = IndexOfDataSetRow(tedarikciIadeFatura.tedarikciIadeFaturaId);
            //    dataSet.Tables[0].Rows.RemoveAt(dataSetIndex);
            //}
        }
        /// <summary>
        /// Formu kapatır ve activeformstack listesinden siler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        /// <summary>
        /// Gride yüklenecek datayı veritabanından çekip dataset nesnesine ekler.
        /// </summary>
        /// <param name="tedarikciIadeFatura"></param>
        /// <returns></returns>
        //private async Task<DataSet> GetDataSet(TedarikciIadeFatura tedarikciIadeFatura)
        //{
        //    try
        //    {
        //        var httpTask = WebMethods.GetFilteredTedarikciIadeFatura(tedarikciIadeFatura);
        //        this.Enabled = false;
        //        string result = await httpTask;
        //        this.Enabled = true;
        //        if (result.Length > 6 && result.Substring(0, 5) == "error")
        //        {
        //            MessageBox.Show(result);
        //        }
        //        else
        //        {
        //            byte[] bytes = JsonConvert.DeserializeObject<byte[]>(result);
        //            string json = Encoding.UTF8.GetString(bytes);
        //            _dataSet = JsonConvert.DeserializeObject<DataSet>(json);
        //        }
        //        return _dataSet;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return _dataSet;
        //    }

        //}
        /// <summary>
        /// Tüm tedarikçi iade faturalarını gridde listeler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public async void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        //{
        //    TedarikciIadeFatura tedarikciIadeFatura = new TedarikciIadeFatura();
        //    await GetDataSet(tedarikciIadeFatura);
        //    dataGridViewTedarikciIadeFatura.Rows.Clear();
        //    int i = 0;
        //    if (_dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in _dataSet.Tables[0].Rows)
        //        {
        //            dataGridViewTedarikciIadeFatura.Rows.Add();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaId"].Value = dr["TedarikciIadeFaturaId"].ToString();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["ProjeKod"].Value = dr["ProjeKod"].ToString();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaNo"].Value = dr["TedarikciIadeFaturaNo"].ToString();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaTarihi"].Value = DateTime.Parse(dr["TedarikciIadeFaturaTarihi"].ToString()).ToShortDateString();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["CariAdi"].Value = dr["CariAdi"].ToString();
        //            dataGridViewTedarikciIadeFatura.Rows[i].Cells["FaturaTutari"].Value = float.Parse(dr["FaturaTutari"].ToString()).ToString("#,##0.00") + " " + dr["DovizSembol"].ToString();
        //            i++;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Görüntülenecek kayıt bulunamadı");
        //    }
        //}
        /// <summary>
        /// Monthcalendar nesnesini görünür hale getirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewMonthCalendar(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar1.BringToFront();
            monthCalendar1.SelectionStart = (textBoxTarihFiltre.Text != "") ? DateTime.Parse(textBoxTarihFiltre.Text) : DateTime.Now;
            monthCalendar1.SelectionEnd = (textBoxTarihFiltre.Text != "") ? DateTime.Parse(textBoxTarihFiltre.Text) : DateTime.Now;
            monthCalendar1.Location = new Point(textBoxTarihFiltre.Location.X, textBoxTarihFiltre.Location.Y);
        }
        /// <summary>
        /// Monthcalendar nesnesinden tarih seçimi yapıldığında seçimi textBoxTarihFiltre alanına yazar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBoxTarihFiltre.Text = e.Start.ToShortDateString();
            monthCalendar1.Visible = false;
        }
        /// <summary>
        /// Mouse monthcalendar nesnesinin üzerinden ayrılınca, monthcalendar nesnesini kapatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar1_MouseLeave(object sender, EventArgs e)
        {
            if (!textBoxTarihFiltre.Bounds.Contains(PointToClient(MousePosition)))
            {
                monthCalendar1.Visible = false;
            }
        }
        /// <summary>
        /// Tarih alanında backspace tuşuna basıldığında alanın değerini temizler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTarihFiltre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                textBoxTarihFiltre.Text = "";
            }
        }
        /// <summary>
        /// Yeni tedarikçi iade faturası eklemek için formu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTedarikciIadeFaturaEkle_Click(object sender, EventArgs e)
        {
            TedarikciIadeFaturaKayitFormu tedarikciIadeFaturaKayitFormu = TedarikciIadeFaturaKayitFormu.tedarikciIadeFaturaKayitFormu;
            if(tedarikciIadeFaturaKayitFormu != null) 
            {
                tedarikciIadeFaturaKayitFormu.Show();
                tedarikciIadeFaturaKayitFormu.SaveMode();
            }
        }
        /// <summary>
        /// Filtre alanlarına uygun satırları datasete alır ve gridde listeler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonFiltre_Click(object sender, EventArgs e)
        {
            //TedarikciIadeFatura tedarikciIadeFatura = new TedarikciIadeFatura();
            //tedarikciIadeFatura.tedarikciIadeFaturaNo = textBoxFaturaNoFiltre.Text;
            //if (textBoxTarihFiltre.Text != "")
            //    tedarikciIadeFatura.tedarikciIadeFaturaTarihi = DateTime.Parse(textBoxTarihFiltre.Text);
            //tedarikciIadeFatura.cariKart.cariAdi = textBoxFirmaFiltre.Text;
            //tedarikciIadeFatura.projeKod.kod = textBoxProjeKodFiltre.Text;
            //await GetDataSet(tedarikciIadeFatura);
            //dataGridViewTedarikciIadeFatura.Rows.Clear();
            //int i = 0;
            //if (_dataSet.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in _dataSet.Tables[0].Rows)
            //    {
            //        dataGridViewTedarikciIadeFatura.Rows.Add();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaId"].Value = dr["TedarikciIadeFaturaId"].ToString();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["ProjeKod"].Value = dr["ProjeKod"].ToString();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaNo"].Value = dr["TedarikciIadeFaturaNo"].ToString();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["TedarikciIadeFaturaTarihi"].Value = DateTime.Parse(dr["TedarikciIadeFaturaTarihi"].ToString()).ToShortDateString();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["FirmaId"].Value = dr["Unvan"].ToString();
            //        dataGridViewTedarikciIadeFatura.Rows[i].Cells["FaturaTutari"].Value = float.Parse(dr["FaturaTutari"].ToString()).ToString("#,##0.00") + " " + dr["DovizSembol"].ToString();
            //        i++;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Görüntülenecek kayıt bulubanamadı");
            //}
        }
        public int IndexOfDataSetRow(int id)
        {
            int index = -1;
            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    if (int.Parse(dataSet.Tables[0].Rows[i]["TedarikciIadeFaturaId"].ToString()) == id)
                    {
                        return i;
                    }
                }
            }
            return index;
        }
        private void CloseForm()
        {
            this.Close();
            GlobalData.RemoveLastForm();
            _tedarikciIadeFaturaGridForm = null;
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}

