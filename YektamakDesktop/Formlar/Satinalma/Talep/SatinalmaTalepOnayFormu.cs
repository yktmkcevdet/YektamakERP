using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Proje;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTalepOnayFormu : Form
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly ISatinalmaTalepService _satinalmaService;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableMapper;
        private readonly IConvertHelper _convertHelper;
        public SatinalmaTalepOnayFormu(IJsonConverter jsonConverter, ISatinalmaTalepService satinalmaService, ICache cache, 
            IDataTableMapper dataTableMapper, IConvertHelper convertHelper)
        {
            _jsonConverter = jsonConverter;
            _satinalmaService = satinalmaService;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
            _convertHelper = convertHelper;
            InitializeComponent();
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.CellClick += Grid_CellClick;
        }

        private SatinalmaTalepDTO _satinalmaTalepOnayDTO;
        public SatinalmaTalepDTO satinalmaTalepOnayDTO
        {
            get
            {
                if (_satinalmaTalepOnayDTO == null)
                {
                    _satinalmaTalepOnayDTO = new SatinalmaTalepDTO();
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
        private List<SatinalmaTalepDTO> _satinalmaTalepOnayList;
        public List<SatinalmaTalepDTO> satinalmaTalepOnayList
        {
            get
            {
                if (_satinalmaTalepOnayList == null)
                {
                    _satinalmaTalepOnayList = new List<SatinalmaTalepDTO>();
                }
                return _satinalmaTalepOnayList;
            }
            set { _satinalmaTalepOnayList = value; }
        }
        private void SatinalmaTalepOnayFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
        private async void SatinalmaTalepOnayFormu_Load(object sender, EventArgs e)
        {
            var jsonResult = await _satinalmaService.GetSatinalmaTalep(new SatinalmaTalep());
            Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
            if (result?.result == null)
            {
                return;
            }
            else if(result.result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Satınalma talepleri alınırken hata oluştu: {result.result}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<SatinalmaTalep> satinalmaTalep = _jsonConverter.ToModelList<SatinalmaTalep>(result.result);
                foreach (var item in satinalmaTalep)
                {
                    satinalmaTalepOnayList.Add(ConvertHelper.ToDTO<SatinalmaTalepDTO>(item));
                }
            }
            
            universalGrid1.SetData(satinalmaTalepOnayList, this.Name,true);
        }
        private void universalGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var source = universalGrid1.Grid.DataSource;
            IEnumerable<SatinalmaTalepOnayDTO> list = universalGrid1.Grid.DataSource as IEnumerable<SatinalmaTalepOnayDTO>;
            DataTable dataTable = ConvertHelper.ToDataTable(list);
            GlobalData.DataGridViewCellClick<SatinalmaTalep>(ref dataTable, universalGrid1.Grid, e);
        }
       
        private async void talebiOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepOnayDTO);
            satinalmaTalep.onayKullanici= _cache.kullanici;
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
                //satinalmaTalepOnayList = (List<SatinalmaTalepDTO>)universalGrid1.binding.DataSource;
                satinalmaTalepOnayDTO = satinalmaTalepOnayList[rowIndex];
                contextMenuStrip1.Show(universalGrid1, e.Location);
            }
        }
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;


                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        var satinalmaTalepDTO = (SatinalmaTalepDTO)universalGrid1.Grid.CurrentRow.DataBoundItem;
                        SatinalmaTalep satinalmaTalep = ConvertHelper.ToEntity<SatinalmaTalep>(satinalmaTalepDTO);
                        SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
                        satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                        satinalmaTalepKayitFormu.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
    }
}
