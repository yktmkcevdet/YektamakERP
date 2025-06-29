using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOnayFormu : Form, IForm
    {
        private static IJsonConverter _jsonConverter;
        private static ISatinalmaTalepService _satinalmaService;
        private static ICache _cache;
        private static IDataTableMapper _dataTableMapper;
        private static IConvertHelper _convertHelper;
        public SatinalmaTalepOnayFormu()
        {
            InitializeComponent();
            universalGrid1.kullanici = _cache.kullanici;
            controlsToDisable.Add(this);
        }
        public SatinalmaTalepOnayFormu(IJsonConverter jsonConverter, ISatinalmaTalepService satinalmaService, ICache cache, 
            IDataTableMapper dataTableMapper, IConvertHelper convertHelper)
        {
            _jsonConverter = jsonConverter;
            _satinalmaService = satinalmaService;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
            _convertHelper = convertHelper;
        }

        private SatinalmaTalepOnayDTO _satinalmaTalepOnayDTO;
        public SatinalmaTalepOnayDTO satinalmaTalepOnayDTO
        {
            get
            {
                if (_satinalmaTalepOnayDTO == null)
                {
                    _satinalmaTalepOnayDTO = new SatinalmaTalepOnayDTO();
                }
                return _satinalmaTalepOnayDTO;
            }
            set
            {
                _satinalmaTalepOnayDTO = value;
            }
        }
        private SatinalmaTalepOnayDTO _satinalmaTalepFilter;
        private SatinalmaTalepOnayDTO satinalmaTalepFilter
        {
            get
            {
                if (_satinalmaTalepFilter == null)
                {
                    _satinalmaTalepFilter = new SatinalmaTalepOnayDTO();
                }
                return _satinalmaTalepFilter;
            }
            set { _satinalmaTalepFilter = value; }
        }
        private static List<SatinalmaTalepOnayDTO> _satinalmaTalepOnayList;
        public static List<SatinalmaTalepOnayDTO> satinalmaTalepOnayList
        {
            get
            {
                if (_satinalmaTalepOnayList == null)
                {
                    _satinalmaTalepOnayList = new List<SatinalmaTalepOnayDTO>();
                }
                return _satinalmaTalepOnayList;
            }
            set { _satinalmaTalepOnayList = value; }
        }
        private static SatinalmaTalepOnayFormu _satinalmaTalepOnayFormu;
        private void SatinalmaTalepOnayFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
            universalGrid1.SaveSettings(this.Name);
        }
        private async void SatinalmaTalepOnayFormu_Load(object sender, EventArgs e)
        {
            var result = await _satinalmaService.GetSatinalmaTalep(new SatinalmaTalep());
            var satinalmaTalepOnayList = _jsonConverter.DeserializeToModelList<SatinalmaTalepOnayDTO>(result).Where(t=>t.onayDurum==false);
            DataTable dataTable = ConvertHelper.ToDataTable(satinalmaTalepOnayList);
            SatinalmaTalepOnayFormu.satinalmaTalepOnayList = _dataTableMapper.MapToEntityList<SatinalmaTalepOnayDTO>(dataTable);
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.SetData(SatinalmaTalepOnayFormu.satinalmaTalepOnayList, this.Name,true);
        }
        private void universalGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var source = universalGrid1.Grid.DataSource;
            IEnumerable<SatinalmaTalepOnayDTO> list = universalGrid1.Grid.DataSource as IEnumerable<SatinalmaTalepOnayDTO>;
            DataTable dataTable = ConvertHelper.ToDataTable(list);
            GlobalData.DataGridViewCellClick<SatinalmaTalep>(ref dataTable, universalGrid1.Grid, e);
        }
        public static SatinalmaTalepOnayFormu satinalmaTalepOnayFormu
        {
            get
            {
                if (_satinalmaTalepOnayFormu == null || _satinalmaTalepOnayFormu.IsDisposed)
                {
                    _satinalmaTalepOnayFormu = new SatinalmaTalepOnayFormu();
                    GlobalData.Yetki(ref _satinalmaTalepOnayFormu);
                }
                return _satinalmaTalepOnayFormu;
            }

        }
        private List<Control> _controlsToDisable;

        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTalep satinalmaTalep = _dataTableMapper.MapToEntity<SatinalmaTalep>(ConvertHelper.ToDataRow(satinalmaTalepOnayDTO));
            string result = await _satinalmaService.SatinalmaTalepOnay(satinalmaTalep);
            Result resultModel = _jsonConverter.DeserializeToModelList<Result>(result).FirstOrDefault();
            MessageBox.Show(resultModel.result);
        }

        private void universalGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = universalGrid1.Grid.HitTest(e.X, e.Y);
            int rowIndex = hit.RowIndex;
            if (e.Button == MouseButtons.Right && rowIndex!=-1)
            {
                universalGrid1.Grid.ClearSelection();
                universalGrid1.Grid.Rows[rowIndex].Selected = true;
                satinalmaTalepOnayList = universalGrid1.Grid.DataSource as List<SatinalmaTalepOnayDTO>;
                satinalmaTalepOnayDTO = satinalmaTalepOnayList[rowIndex];
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }

        public List<Control> controlsToDisable
        {
            get { if (_controlsToDisable == null) { _controlsToDisable = new List<Control>(); } return _controlsToDisable; }
            set { _controlsToDisable = value; }
        }
        public bool activeForm { get; set; }
    }
}
