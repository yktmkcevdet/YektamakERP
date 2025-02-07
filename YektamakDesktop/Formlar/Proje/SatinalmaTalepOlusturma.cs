using Models;
using ApiService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utilities.Interfaces;
using Utilities.Implementations;

namespace YektamakDesktop.Formlar.Proje
{
    public partial class SatinalmaTalepOlusturma : Form, IForm
    {
        private readonly ICache _cache;
        private WebMethods _webMethods;
        public SatinalmaTalepOlusturma(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            dataTable = Common.ConvertHelper.ToDataTable(stokKarts);

        }
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
            set { _stokKarts = value; }
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
                    _dataTable = Common.ConvertHelper.ToDataTable(stokKarts);
                }
                return _dataTable;
            }
            set 
            {
                DataRefresh();
                _dataTable = value; 
            }
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
                return _stokKartFilter;
            }
            set { _stokKartFilter = value; }
        }
        private static SatinalmaTalepOlusturma _satinalmaTalepOlusturma;
        public static SatinalmaTalepOlusturma satinalmaTalepOlusturma
        {
            get
            {
                if (_satinalmaTalepOlusturma == null)
                {
                    _satinalmaTalepOlusturma = new SatinalmaTalepOlusturma(new Cache(new JsonConvertHelper(),new DataTableConverter()));
                    GlobalData.Yetki(ref _satinalmaTalepOlusturma);
                }
                return _satinalmaTalepOlusturma;
            }
        }

        public List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        public bool _activeForm;

        private void roundedButton3_Click(object sender, EventArgs e)
        {
           CloseForm();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            SatinalmaTalepBaslik satinalmaTalepBaslik = new SatinalmaTalepBaslik();
            satinalmaTalepBaslik.proje.Id = customComboListBoxProjeKodu.selectedDataRowId;
            satinalmaTalepBaslik.parcaGrupId = customComboListBoxParcaGrubu.selectedDataRowId;
            satinalmaTalepBaslik.talepTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            foreach(DataGridViewRow row in dataGridViewSatinalma.Rows)
            {
                SatinalmaTalepDetay satinalmaTalepDetay = new SatinalmaTalepDetay();
                satinalmaTalepDetay.stokKart.Id = Convert.ToInt32(row.Cells["Id"].Value.ToString()) ;
                satinalmaTalepDetay.miktar = Convert.ToDouble(row.Cells["miktar"].Value.ToString());
                satinalmaTalepBaslik.satinalmaTalepDetay.Add(satinalmaTalepDetay);
            }
            string result=WebMethods.SaveSatinalmaTalep(satinalmaTalepBaslik);
        }

        public bool activeForm { get => _activeForm; set => _activeForm = value; }
        public void SaveMode(long projeKod, long parcaGrupId, DataTable dataTable)
        {
            Models.Proje proje = new();
            proje.personel = _cache.kullanici.personel;
            string jsonString = WebMethods.GetProjeKodByUserId(proje);
            
            IJsonConvertHelper jsonConverter = new JsonConvertHelper();
            DataSet dataSet = jsonConverter.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Models.Proje proje1;
                proje1 = Common.ConvertHelper.DataRowToModel<Models.Proje>(dataRow);
                customComboListBoxProjeKodu.AddDataRow(proje1.Id, proje1.kod);
            }
            customComboListBoxProjeKodu.SelectDataRowId(projeKod);
            string jsonStringParcaGrup = WebMethods.GetParcaGrup(new ParcaGrup());
            DataSet dataSetParcaGrup = jsonConverter.JsonStringToDataSet(jsonStringParcaGrup);
            customComboListBoxParcaGrubu.AddDataRow(0, "<Tüm Kayıtlar>");
            foreach (DataRow dataRow in dataSetParcaGrup.Tables[0].Rows)
            {
                ParcaGrup parcaGrup;
                parcaGrup = Common.ConvertHelper.DataRowToModel<ParcaGrup>(dataRow);
                customComboListBoxParcaGrubu.AddDataRow(parcaGrup.Id, parcaGrup.kod);
            }
            customComboListBoxParcaGrubu.SelectDataRowId(parcaGrupId);
            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = dataGridViewSatinalma.Rows.Add();
                foreach (DataColumn column in dataTable.Columns)
                {
                    if(dataGridViewSatinalma.Columns.Contains(column.ColumnName))
                        dataGridViewSatinalma.Rows[rowIndex].Cells[column.ColumnName].Value = row[column.ColumnName];
                }
            }
            lblKayitSayisi.Text = $"Toplam kayıt sayısı: {dataTable.Rows.Count}";
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalma, stokKartFilter);
            DataTable fa=_dataTable;
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridViewSatinalma.RowCount}";
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaTalepOlusturma);
        }
    }
}
