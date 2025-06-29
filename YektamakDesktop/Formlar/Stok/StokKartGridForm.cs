using ApiService.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Genel;
using DataTable = System.Data.DataTable;

namespace YektamakDesktop.Formlar.Stok
{
    public partial class StokKartGridForm : Form, IForm, IGridForm<StokKart>
    {
        private static IStokService _stokService;
        private static ICache _cache;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public StokKartGridForm(IStokService stokService)
        {
            _stokService = stokService;
        }
        private static StokKartGridForm _stokKartGridForm;
        public static StokKartGridForm stokKartGridForm
        {
            get
            {
                if (_stokKartGridForm == null)
                {
                    _stokKartGridForm = new StokKartGridForm();
                    GlobalData.Yetki(ref _stokKartGridForm);
                }
                return _stokKartGridForm;
            }
            set
            {
                _stokKartGridForm = value;
            }
        }
        public StokKartGridForm()
        {
            InitializeComponent();
            controlsToDisable = new List<Control> { panelFilter, panelHeader };
            ComboBoxListFill.GetLookupKod(_cache.projes, ref projeKodu);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref cbxStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref cbxMalzemeGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List, ref cbxMalzemeAltGrup2);
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups, ref cbxMalzemeAltGrup);
            ComboBoxListFill.GetLookupAd(_cache.stokTips, ref cbxStokTip);
        }
        public StokKartGridForm(ICache cache, IJsonConverter jsonConvertHelper, IStokService stokService,IDataTableMapper dataTableMapper)
        {
            _cache = cache;
            _jsonConverter = jsonConvertHelper;
            _stokService = stokService;
            _dataTableMapper = dataTableMapper;
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
        private static List<StokKart> _stokKarts;
        public static List<StokKart> stokKarts
        {
            get
            {
                if (_stokKarts == null)
                {
                    _stokKarts = new List<StokKart>();
                }
                return _stokKarts;
            }
            set
            {
                _stokKarts = value;
            }
        }

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
                if (_dataTable.Rows.Count == 0)
                {
                    _dataTable = ConvertHelper.ToDataTable(stokKarts);
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                DataRefresh();
            }
        }
        public async Task<DataTable> GetDataTableAsync()
        {
            if (_dataTable == null)
            {
                _dataTable = new DataTable();
                
            }

            if (_dataTable.Rows.Count == 0)
            {
                _dataTable = await GlobalData.FillDataTableAsync(_stokService.GetStokKart, stokKartFilter);
            }
            _dataTable.RowDeleted += dataTableRowChanged;
            _dataTable.RowChanged += dataTableRowChanged;
            DataRefresh();
            return _dataTable;
        }
        private StokKart _stokKartFilter;
        private StokKart stokKartFilter
        {
            get
            {
                if (_stokKartFilter == null)
                {
                    _stokKartFilter = new StokKart();
                }
                if (_stokKartFilter.proje.Id == 0)
                {
                    _stokKartFilter.proje.Id = -1;
                }
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;
        public bool activeForm
        {
            get { return _activeForm; }
            set
            {
                _activeForm = value;
            }
        }

        private void DataRefresh()
        {
           label7.Text= GlobalData.FillDataGrid(_dataTable, dataGridViewStokKart, stokKartFilter);
            //_dataTable.Rows.Cast<DataRow>().ToList().ForEach(row => row["sec"] = false);

            lblKayitSayisi.Text = $"Görüntülenen Kayıt Sayısı: {dataGridViewStokKart.RowCount}";
            lblToplamKayitSayisi.Text = $"Toplam Kayıt Sayısı: {_dataTable.Rows.Count}";
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        public void dataTableRowInserted(object sender, DataTableNewRowEventArgs e)
        {
            DataRefresh();
        }
        private async void malzemeGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrups.Where(x => x.malzemeGrup.Id == stokKartFilter.malzemeGrup.Id).ToList(), ref cbxMalzemeAltGrup);
            await GetDataTableAsync();
        }

        public void UpdateRow(StokKart stokKart)
        {
            int i = GlobalData.IndexOfDataSet(_dataTable, stokKart.Id ?? 0);
            if (i == -1)
            {
                AddNewRow(stokKart);
            }
            else
            {
                GlobalData.UpdateDataRow(ref _dataTable, stokKart, i);
            }
        }

        public async void AddNewRow(StokKart stokKart)
        {
            await GetDataTableAsync();
            DataRow dataRow = ConvertHelper.ToDataRow(stokKart);
            dataTable.Rows.Add(dataRow);
        }

        public void form_Load(object sender, EventArgs e)
        {
            //GlobalData.PlaceFilterFields(dataGridViewStokKart, panelFilter);
        }

        public void buttonEkle_Click(object sender, EventArgs e)
        {
            StokKartKayitFormu stokKartTanimlamaFormu = StokKartKayitFormu.stokKartKayitFormu;
            stokKartTanimlamaFormu.stokKart.malzemeGrup.Id = cbxMalzemeGrup.selectedDataRowId;
            stokKartTanimlamaFormu.stokKart.malzemeAltGrup.Id = cbxMalzemeAltGrup.selectedDataRowId;
            stokKartTanimlamaFormu.stokKart.malzemeAltGrup2.Id = cbxMalzemeAltGrup2.selectedDataRowId;
            if (stokKartTanimlamaFormu != null)
            {
                stokKartTanimlamaFormu.Show();
            }
        }

        public async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            StokKart stokKartDosya = new StokKart();
            stokKartDosya.Id = Convert.ToInt32(dataGridViewStokKart.Rows[e.RowIndex].Cells["Id"].Value);
            var stokKart=_jsonConverter.DeserializeToModelList<StokKart>(await _stokService.GetStokKartPdf(stokKartDosya)).FirstOrDefault();
            var dataRow= ConvertHelper.ToDataRow(stokKart);
            int dtId = GlobalData.IndexOfDataSet(_dataTable, int.Parse(dataGridViewStokKart.Rows[e.RowIndex].Cells[0].Value.ToString()));
            _dataTable.Rows[dtId].ItemArray = dataRow.ItemArray;
            GlobalData.DataGridViewCellClick<StokKart>(ref _dataTable, dataGridViewStokKart, e);
        }

        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        public void buttonFiltre_Click(object sender, EventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewStokKart, panelFilter);
        }

        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            GlobalData.ResizeFilterFields(dataGridViewStokKart, panelFilter);
        }

        public void buttonClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int oldScrollOffset = 0;
        public void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            GlobalData.AdjustControlsOnScroll(dataGridViewStokKart, panelFilter, e, ref oldScrollOffset);
        }

        private async void projeKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.proje.Id = projeKodu.selectedDataRowId;
            await GetDataTableAsync();
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _stokKartGridForm);
        }

        private async void cbxStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokGrup.Id = cbxStokGrup.selectedDataRowId;
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups.Where(x => x.stokGrup.Id == stokKartFilter.stokGrup.Id).ToList(), ref cbxMalzemeGrup);
            await GetDataTableAsync();
        }

        private async void cbxMalzemeAltGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.malzemeAltGrup.Id = cbxMalzemeAltGrup.selectedDataRowId;
            var a = _cache.malzemeAltGrup2List.ToList();
            MalzemeAltGrup malzemeAltGrup = new MalzemeAltGrup();
            malzemeAltGrup = a[0].malzemeAltGrup;
            ComboBoxListFill.GetLookupAd(_cache.malzemeAltGrup2List.Where(x => x.malzemeAltGrup.Id == stokKartFilter.malzemeAltGrup.Id).ToList(), ref cbxMalzemeAltGrup2);
            await GetDataTableAsync();
        }

        private void cbxMalzemeAltGrup2_DoubleClick(object sender, EventArgs e)
        {
            DIContainer.GetService<AnaVeriTanimlamaFormu<MalzemeAltGrup2>>();
            AnaVeriTanimlamaFormu<MalzemeAltGrup2> anaVeriTanimlamaFormu = AnaVeriTanimlamaFormu<MalzemeAltGrup2>.anaVeriTanimlamaFormu;
            if (anaVeriTanimlamaFormu != null) anaVeriTanimlamaFormu.Show();
        }

        private async void cbxStokTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            stokKartFilter.stokTip.Id = cbxStokTip.selectedDataRowId;
            await GetDataTableAsync();
        }
    }

}
