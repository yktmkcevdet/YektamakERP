using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Models;
using System.Threading.Tasks;
using System.Linq;
using YektamakDesktop.Abstracts;
using ApiService;
using YektamakDesktop.Common;
using Utilities.Interfaces;
using ApiService.Interfaces;
using System.Text;
using Newtonsoft.Json;

namespace YektamakDesktop.Formlar.Satis
{
    /// <summary>
    /// FirmaGridFormunun kopyasıdır. DataGrid pencereleri için bir template gibi değiştirilerek kullanılması için oluşturulmuştur.
    /// </summary>
    public partial class SatisSiparisTeklifTalepGridForm : Form
    {
        private static ICache _cache;
        private static IJsonConverter _jsonConvertHelper;
        private static IDataTableMapper _dataTableHelper;
        private static ISatisService _satisService;
        private static IMailHandler _mailHandler;
        public SatisSiparisTeklifTalepGridForm(ICache cache, IJsonConverter jsonConvertHelper, IDataTableMapper dataTableHelper, ISatisService satisService, IMailHandler mailHandler)
        {
            _dataTableHelper = dataTableHelper;
            _cache = cache;
            _jsonConvertHelper = jsonConvertHelper;
            _satisService = satisService;
            _mailHandler = mailHandler;
        }
        private static SatisSiparisTeklifTalepGridForm _satisSiparisTeklifTalepGridForm;
        public static SatisSiparisTeklifTalepGridForm satisSiparisTeklifTalepGridForm
        {
            get
            {
                if (_satisSiparisTeklifTalepGridForm == null)
                {
                    _satisSiparisTeklifTalepGridForm = new SatisSiparisTeklifTalepGridForm();
                }
                return _satisSiparisTeklifTalepGridForm;
            }
        }
        
        public static List<SatisTeklifTalep> satisSiparisTeklifTalepList = new List<SatisTeklifTalep>();
        /// <summary>
        /// dataSet ve grid içeriği aynı olmalı
        /// </summary>
        private DataTable _dataTable;

        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
        }
        private SatisTeklifTalep satisSiparisTeklifTalepFilter
        {
            get;set;
        }
        ToolTip buttonFiltreToolTip;
        private SatisSiparisTeklifTalepGridForm()
        {
            InitializeComponent();
            SetToolTips();
        }
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Satış Siparişleri Filtreleme";
            buttonFiltreToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonFiltreToolTip.AutoPopDelay = 20000;
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

        /// <summary>
        /// Filtre alanlarına uygun olarak kayıtları gride doldurur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Kullanıcıya silme işlemi için onay sorusu gösterir ve işlemi gerçekleştirir.
        /// Silme işlemi başarılı olduğunda, kullanıcıya bilgi mesajı gösterilir ve grid güncellenir.
        /// </summary>
        /// <param name="satisTeklifTalep"></param>
        /// <param name="rowId"></param>
        private async Task DeleteSatisSiparis(SatisTeklifTalep satisTeklifTalep)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("{0} nolu teklif talebini silmek istediğinizden emin misiniz", satisTeklifTalep.Id), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var httpTask = _satisService.DeleteSatisSiparisTeklifTalep(satisTeklifTalep.Id.ToString());
                this.Enabled = false;
                string result = await httpTask;
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                }
                this.Enabled = true;
            }
        }
        /// <summary>
        /// Silme veya güncelleme işlemi için gerekli verileri toplar ve işlemleri gerçekleştirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSatisSiparis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGridView.Rows[e.RowIndex].Selected = true;
            if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
                    return;


                if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                {
                    UpdateTeklifTalep(SelectedData(e.RowIndex));
                }
                else if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                {
                    DeleteSatisSiparis(SelectedData(e.RowIndex));
                }
            }
        }
        /// <summary>
        /// DataGridview nesnesinde üzerinde bulunulan satırın değerlerini satisProje nesnesi olarak döndürür.
        /// </summary>
        /// <returns></returns>
        private SatisTeklifTalep SelectedData(int rowIndex)
        {
            if (dataTable == null || rowIndex < 0) return null;
            if (rowIndex >= dataTable.Rows.Count) return null;
            SatisTeklifTalep satisSiparisTeklifTalep = new SatisTeklifTalep();
            int teklifTalepId = int.Parse(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
            satisSiparisTeklifTalep.Id = teklifTalepId;
            return satisSiparisTeklifTalep;
        }
        /// <summary>
        /// Verilen SatisProje nesnesinin güncelleme işlemi için formu açar.
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateTeklifTalep(SatisTeklifTalep satisSiparisTeklifTalep)
        {
            SatisTeklifTalepKayitFormu satisSiparisTeklifTalepKayitFormu = SatisTeklifTalepKayitFormu.satisTeklifTalepKayitFormu;
            if (satisSiparisTeklifTalepKayitFormu != null)
            {
                satisSiparisTeklifTalepKayitFormu.satisSiparisTeklifTalep = satisSiparisTeklifTalep;
                satisSiparisTeklifTalepKayitFormu.Show();
            }
        }
        private void buttonFiltre_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Yeni bir satış siparişi eklemek için satisSiparisTeklifTalepKayitFormu'nu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSatisSiparisEkle_Click(object sender, EventArgs e)
        {
            SatisTeklifTalepKayitFormu satisTeklifTalepKayitFormu = SatisTeklifTalepKayitFormu.satisTeklifTalepKayitFormu;
            if (satisTeklifTalepKayitFormu != null)
            {
                satisTeklifTalepKayitFormu.Show();
            }
        }
        private void CloseForm()
        {
        }
        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void SatisSiparisTeklifTalepGridForm_Load(object sender, EventArgs e)
        {
        }
        public void UpdateRow(SatisTeklifTalep satisSiparisTeklifTalep)
        {
        }
        private void AddNewRow(SatisTeklifTalep satisSiparisTeklifTalep)
        {
            dataTable.Rows.Add(
                satisSiparisTeklifTalep.Id

                );
        }
        int oldScrollOffset = 0;
        private void dataGridViewSatisSiparisTeklifTalep_Scroll(object sender, ScrollEventArgs e)
        {
        }
        private void dataGridViewSatisSiparisTeklifTalep_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
        }

        private async void maliyetTalep_Click(object sender, EventArgs e)
        {
            SatisTeklifTalep satisTeklifTalep = SelectedData(dataGridView.CurrentRow.Index);
            if (satisTeklifTalep == null) return;
            if (satisTeklifTalep.isMaliyetTalep == true)
            {
                MessageBox.Show("Bu teklif talebi için daha önce maliyet talebi iletilmiştir.");
            }
            else
            {
                satisTeklifTalep.isMaliyetTalep = true;
            }
            string result = await _satisService.SaveSatisSiparisTeklifTalep(satisTeklifTalep);
            if (result.Contains("error"))
            {
                MessageBox.Show(result);
            }
            else
            {
                _mailHandler.SendMail("cevdet.oguz@yektamak.com.tr", "Maliyet Talebi", $"{satisTeklifTalep.musteri.ad} müşteri teklifi için maliyet talebi istenmektedir.");
                MessageBox.Show("Maliyet talebi başarıyla iletilmiştir.");
            }
        }

        private void dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == dataGridView.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
            {
                Cursor.Current = Cursors.Hand;
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Sağ tıklama kontrolü
            {
                var hitTestInfo = dataGridView.HitTest(e.X, e.Y); // Tıklanan hücreyi belirle

                if (hitTestInfo.RowIndex >= 0) // Eğer geçerli bir satır tıklanmışsa
                {
                    dataGridView.ClearSelection(); // Önceki seçimleri temizle
                    dataGridView.Rows[hitTestInfo.RowIndex].Selected = true; // Tıklanan satırı seç
                    contextMenuStrip1.Show(dataGridView, e.Location); // Sağ tıklama menüsünü göster
                }
            }
        }

        private void maliyetFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatisTeklifMaliyetKayitFormu satisTeklifMaliyetKayitFormu = SatisTeklifMaliyetKayitFormu.satisTeklifMaliyetKayitFormu;
            if (satisTeklifMaliyetKayitFormu != null)
            {
                satisTeklifMaliyetKayitFormu.satisTeklifTalep = SelectedData(dataGridView.CurrentRow.Index);
                satisTeklifMaliyetKayitFormu.Show();
            }
        }
    }
}