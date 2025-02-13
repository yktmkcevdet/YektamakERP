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

namespace YektamakDesktop.Formlar.Satis
{
    /// <summary>
    /// FirmaGridFormunun kopyasıdır. DataGrid pencereleri için bir template gibi değiştirilerek kullanılması için oluşturulmuştur.
    /// </summary>
    public partial class SatisSiparisTeklifTalepGridForm : Form, IForm
    {
        private static SatisSiparisTeklifTalepGridForm _satisSiparisTeklifTalepGridForm;
        public static SatisSiparisTeklifTalepGridForm satisSiparisTeklifTalepGridForm
        {
            get
            {
                if (_satisSiparisTeklifTalepGridForm == null)
                {
                    _satisSiparisTeklifTalepGridForm = new SatisSiparisTeklifTalepGridForm();
                    GlobalData.Yetki(ref _satisSiparisTeklifTalepGridForm);
                }
                return _satisSiparisTeklifTalepGridForm;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public static List<SatisSiparisTeklifTalep> satisSiparisTeklifTalepList = new List<SatisSiparisTeklifTalep>();
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
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
                    _dataTable = GlobalData.FillDataTable(WebMethods.GetSatisSiparisTeklifTalep, satisSiparisTeklifTalepFilter);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set { _dataTable = value; }
        }
        private void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satisSiparisTeklifTalepFilter);
        }
        private SatisSiparisTeklifTalep satisSiparisTeklifTalepFilter
        {
            get
            {
                return GlobalData.GridFilter<SatisSiparisTeklifTalep>(panelFilter);
            }
        }
        ToolTip buttonFiltreToolTip;
        public SatisSiparisTeklifTalepGridForm()
        {
            InitializeComponent();
            SetToolTips();
            controlsToDisable = new List<Control>
            {
                buttonFiltre,
                buttonSatisSiparisTeklifTalepEkle,
                buttonTumKayitlariGetir,
                dataGridView,
                rButtonCikis
            };

        }
        /// <summary>
        /// Form kontrollerinin ToolTip ayarlarını yapar
        /// </summary>
        public void SetToolTips()
        {
            buttonFiltreToolTip = new ToolTip();
            buttonFiltreToolTip.ToolTipTitle = "Satış Siparişleri Filtreleme";
            buttonFiltreToolTip.SetToolTip(buttonFiltre, "Sol taraftaki ifadeleri içeren filtrelenmiş sonuçları getirir");
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
        /// Formu kapatır ve activeFormStack listesinden çıkartır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rButtonCikis_Click(object sender, EventArgs e)
        {
            GlobalData.CloseForm(ref _satisSiparisTeklifTalepGridForm);
        }
        /// <summary>
        /// Filtre alanlarına uygun olarak kayıtları gride doldurur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satisSiparisTeklifTalepFilter);
        }
        /// <summary>
        /// Kullanıcıya silme işlemi için onay sorusu gösterir ve işlemi gerçekleştirir.
        /// Silme işlemi başarılı olduğunda, kullanıcıya bilgi mesajı gösterilir ve grid güncellenir.
        /// </summary>
        /// <param name="satisSiparis"></param>
        /// <param name="rowId"></param>
        private async Task DeleteSatisSiparis(SatisSiparis satisSiparis)
        {
            DialogResult dialogResult = MessageBox.Show(string.Format("{0} nolu siparişi silmek istediğinizden emin misiniz", satisSiparis.siparisNo), "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var httpTask = WebMethods.DeleteSatisSiparis(satisSiparis);
                this.Enabled = false;
                string result = await httpTask;
                if (result.Length > 6 && result.Substring(0, 5) == "error")
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi Başarılı");
                    int i = GlobalData.IndexOfDataSet(dataTable, satisSiparis.Id);
                    dataTable.Rows[i].Delete();
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
                    UpdateSatisSiparis(SelectedData(e.RowIndex));
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
        private SatisSiparis SelectedData(int rowIndex)
        {
            if (dataTable == null || rowIndex < 0) return null;
            if (rowIndex >= dataTable.Rows.Count) return null;
            SatisSiparis satisSiparis = new SatisSiparis();
            int siparisId = int.Parse(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
            satisSiparis.Id = siparisId;
            int i = GlobalData.IndexOfDataSet(dataTable, siparisId);
            satisSiparis = ConvertHelper.DataRowToModel<SatisSiparis>(dataTable.Rows[i]);
            return satisSiparis;
        }
        /// <summary>
        /// Verilen SatisProje nesnesinin güncelleme işlemi için formu açar.
        /// </summary>
        /// <param name="firma"></param>
        public void UpdateSatisSiparis(SatisSiparis satisSiparis)
        {
            SatisSiparisTeklifTalepKayitFormu satisSiparisTeklifTalepKayitFormu = SatisSiparisTeklifTalepKayitFormu.satisSiparisTeklifTalepKayitFormu;
            if (satisSiparisTeklifTalepKayitFormu != null)
            {
                satisSiparisTeklifTalepKayitFormu.Show();
            }
        }
        private void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.FillDataGrid(dataTable, dataGridView, satisSiparisTeklifTalepFilter);
        }
        /// <summary>
        /// Yeni bir satış siparişi eklemek için satisSiparisTeklifTalepKayitFormu'nu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSatisSiparisEkle_Click(object sender, EventArgs e)
        {
            SatisSiparisTeklifTalepKayitFormu satisSiparisTeklifTalepKayitFormu = SatisSiparisTeklifTalepKayitFormu.satisSiparisTeklifTalepKayitFormu;
            if (satisSiparisTeklifTalepKayitFormu != null)
            {
                satisSiparisTeklifTalepKayitFormu.Show();
            }
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satisSiparisTeklifTalepGridForm);
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
            GlobalData.PlaceFilterFields(dataGridView, panelFilter);
        }
        public void UpdateRow(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satisSiparisTeklifTalep.teklifTalepId);
            if (i == -1)
            {
                AddNewRow(satisSiparisTeklifTalep);
            }
            else
            {
                GlobalData.UpdateDataRow(dataTable, satisSiparisTeklifTalep, i);
            }
        }
        private void AddNewRow(SatisSiparisTeklifTalep satisSiparisTeklifTalep)
        {
            dataTable.Rows.Add(
                satisSiparisTeklifTalep.teklifTalepId
               
                );
        }
        int oldScrollOffset = 0;
        private void dataGridViewSatisSiparisTeklifTalep_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridView, panelFilter, e, ref oldScrollOffset);
        }
        private void dataGridViewSatisSiparisTeklifTalep_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridView, panelFilter);
        }

        private void labelHeader_Click(object sender, EventArgs e)
        {

        }
    }
}