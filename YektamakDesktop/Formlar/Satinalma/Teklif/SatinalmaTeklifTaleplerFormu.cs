using ApiService.Implementetions;
using ApiService.Interfaces;
using MathNet.Numerics;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Satinalma.Teklif;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTeklifTaleplerFormu : Form
    {
        private static ISatinalmaTeklifService _satinalmaTeklifService;
        private static IJsonConverter _jsonConverter;
        private static IDataTableMapper _dataTableMapper;
        public SatinalmaTeklifTaleplerFormu()
        {
            InitializeComponent();
            universalGrid1.Grid.CellClick += dataGridViewSatinalmaTeklifTalepler_CellClick;
        }
        private List<SatinalmaTeklifBaslikDTO> _satinalmaTeklifDTOs;
        public List<SatinalmaTeklifBaslikDTO> satinalmaTeklifDTOs
        {
            get
            {
                if (_satinalmaTeklifDTOs == null)
                {
                    _satinalmaTeklifDTOs = new();
                }
                return _satinalmaTeklifDTOs;
            }
            set
            {
                _satinalmaTeklifDTOs = value;
            }
        }
        public SatinalmaTeklifTaleplerFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, IDataTableMapper dataTableMapper)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _dataTableMapper = dataTableMapper;
        }
        private static SatinalmaTeklifTaleplerFormu _satinalmaTeklifTaleplerFormu;
        public static SatinalmaTeklifTaleplerFormu satinalmaTeklifTaleplerFormu
        {
            get
            {
                if (_satinalmaTeklifTaleplerFormu == null || _satinalmaTeklifTaleplerFormu.IsDisposed)
                {
                    _satinalmaTeklifTaleplerFormu = new SatinalmaTeklifTaleplerFormu();
                    GlobalData.Yetki(ref _satinalmaTeklifTaleplerFormu);
                }
                return _satinalmaTeklifTaleplerFormu;
            }
        }

        private async void SatinalmaTeklifTaleplerFormu_Load(object sender, EventArgs e)
        {
            try
            {
                var teklifler = await _satinalmaTeklifService.GetSatinalmaTeklif(new Models.SatinalmaTeklifBaslik());
                Result result = _jsonConverter.DeserializeToModelList<Result>(teklifler)[0];
                if (result.result != null)
                {
                    var satinalmaTeklifBaslik = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(result.result);
                    DataTable dataTable = Common.ConvertHelper.ToDataTable(satinalmaTeklifBaslik);
                    satinalmaTeklifDTOs = _dataTableMapper.MapToEntityList<SatinalmaTeklifBaslikDTO>(dataTable);
                }
                universalGrid1.SetData(satinalmaTeklifDTOs, this.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private async void dataGridViewSatinalmaTeklifTalepler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;


                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        var aaa = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
                        DataTable dataTable = Common.ConvertHelper.ToDataTable(satinalmaTeklifDTOs);
                        SatinalmaTeklifBaslik satinalmaTeklifBaslik = _dataTableMapper.MapToEntity<SatinalmaTeklifBaslik>(dataTable.Rows[e.RowIndex]);
                        SatinalmaTeklifKayitFormu satinalmaTeklifKayitFormu = SatinalmaTeklifKayitFormu.satinalmaTeklifKayitFormu;
                        satinalmaTeklifKayitFormu.UpdateMode(satinalmaTeklifBaslik);
                        satinalmaTeklifKayitFormu.Show();
                    }
                    else if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                    {
                        var aaa = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
                        DataTable dataTable = Common.ConvertHelper.ToDataTable(satinalmaTeklifDTOs);
                        SatinalmaTeklifBaslik satinalmaTeklifBaslik = _dataTableMapper.MapToEntity<SatinalmaTeklifBaslik>(dataTable.Rows[e.RowIndex]);
                        string jsonResult = await _satinalmaTeklifService.DeleteSatinalmaTeklif(satinalmaTeklifBaslik);
                        Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                        MessageBox.Show(result.result);
                        universalGrid1.binding.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

        }
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRefresh();
        }
        private void DataRefresh()
        {
            universalGrid1.binding.DataSource = satinalmaTeklifDTOs;
        }

        private void SatinalmaTeklifTaleplerFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings(this.Name);
        }
        
    }
}
