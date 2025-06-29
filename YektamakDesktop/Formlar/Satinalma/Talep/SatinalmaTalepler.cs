using ApiService.Interfaces;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Proje;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepler : Form, IForm
    {
        private static IDataTableMapper _dataTableMapper;
        private static ISatinalmaTalepService _satinalmaService;
        private static IJsonConverter _jsonConverter;
        private static ICache _cache;
        private SatinalmaTalepler()
        {
            InitializeComponent();
            _controlsToDisable = new List<Control>();
        }
        public SatinalmaTalepler(IDataTableMapper dataTableMapper, ISatinalmaTalepService satinalmaService, IJsonConverter jsonConverter, ICache cache)
        {
            _dataTableMapper = dataTableMapper;
            _satinalmaService = satinalmaService;
            _jsonConverter = jsonConverter;
            _cache = cache;
        }
        private static SatinalmaTalepler _satinalmaTalepler;
        public static SatinalmaTalepler satinalmaTalepler
        {
            get
            {
                if (_satinalmaTalepler == null)
                {
                    _satinalmaTalepler = new SatinalmaTalepler();
                    GlobalData.Yetki(ref _satinalmaTalepler);
                }
                return _satinalmaTalepler;
            }
            set
            {
                _satinalmaTalepler = value;
            }
        }
        private static List<SatinalmaTalep> _satinalmaTaleps;
        public static List<SatinalmaTalep> satinalmaTaleps
        {
            get
            {
                if (_satinalmaTaleps == null)
                {
                    _satinalmaTaleps = new List<SatinalmaTalep>();
                }
                return _satinalmaTaleps;
            }
            set
            {
                _satinalmaTaleps = value;
            }
        }
        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }
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
        private DataTable _dataTable;
        private DataTable dataTable
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                    
                }
                if (_dataTable.Rows.Count == 0)
                {
                    _dataTable = ConvertHelper.ToDataTable(satinalmaTaleps);
                    _dataTable.RowDeleted += dataTableRowChanged;
                    _dataTable.RowChanged += dataTableRowChanged;
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                DataRefresh();
            }
        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private SatinalmaTalep _satinalmaTalepFilter;
        private SatinalmaTalep satinalmaTalepFilter
        {
            get
            {
                if (_satinalmaTalepFilter == null)
                {
                    _satinalmaTalepFilter = new SatinalmaTalep();
                }
                return _satinalmaTalepFilter;
            }
            set { _satinalmaTalepFilter = value; }
        }
        private void DataRefresh()
        {
            GlobalData.FillDataGrid(dataTable, dataGridViewSatinalmaTalepler, satinalmaTalepFilter);
            lblKayitSayisi.Text = $"Toplam Kayıt Sayısı: {dataGridViewSatinalmaTalepler.RowCount}";
        }

        private async void SatinalmaTalepler_Load(object sender, EventArgs e)
        {
            string result = await _satinalmaService.GetSatinalmaTalep(satinalmaTalepFilter);
            satinalmaTaleps = _jsonConverter.DeserializeToModelList<SatinalmaTalep>(result);
            DataRefresh();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            GlobalData.CloseForm(ref _satinalmaTalepler);
        }

        private void dataGridViewSatinalmaTalepler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GlobalData.DataGridViewCellClick<SatinalmaTalep>(ref _dataTable, dataGridViewSatinalmaTalepler, e);
        }
        public void UpdateRow(SatinalmaTalep satinalmaTalep)
        {
            int i = GlobalData.IndexOfDataSet(dataTable, satinalmaTalep.Id);
            if (i == -1)
            {
                AddNewRow(satinalmaTalep);
            }
            else
            {
                GlobalData.UpdateDataRow(ref _dataTable, satinalmaTalep, i);
            }
            DataRefresh();
        }

        public void AddNewRow(SatinalmaTalep satinalmaTalep)
        {
            DataRow dataRow = ConvertHelper.ToDataRow(satinalmaTalep);
            dataTable.Rows.Add(dataRow);
        }

        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            satinalmaTalepFilter.onayKullanici.Id = _cache.kullanici.Id;
            satinalmaTalepFilter.Id=dataGridViewSatinalmaTalepler.SelectedRows[0].Cells["Id"].Value != null ? Convert.ToInt32(dataGridViewSatinalmaTalepler.SelectedRows[0].Cells["Id"].Value) : 0;
            string result=await _satinalmaService.SatinalmaTalepOnay(satinalmaTalepFilter);
            Result resultModel = _jsonConverter.DeserializeToModelList<Result>(result).FirstOrDefault();
            MessageBox.Show(resultModel.result);
        }

        private void dataGridViewSatinalmaTalepler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Sağ tıklama kontrolü
            {
                var hitTestInfo = dataGridViewSatinalmaTalepler.HitTest(e.X, e.Y); // Tıklanan hücreyi belirle

                if (hitTestInfo.RowIndex >= 0) // Eğer geçerli bir satır tıklanmışsa
                {
                    dataGridViewSatinalmaTalepler.ClearSelection(); // Önceki seçimleri temizle
                    dataGridViewSatinalmaTalepler.Rows[hitTestInfo.RowIndex].Selected = true; // Tıklanan satırı seç
                    contextMenuStrip1.Show(dataGridViewSatinalmaTalepler, e.Location); // Sağ tıklama menüsünü göster
                }
            }
        }
    }
}
