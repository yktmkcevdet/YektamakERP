using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Satinalma.Teklif;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTeklifTaleplerFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;
        public SatinalmaTeklifTaleplerFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            universalGrid1.kullanici = _cache.kullanici;
            universalGrid1.Grid.CellClick += universalGrid1_CellClick;
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
        private async void SatinalmaTeklifTaleplerFormu_Load(object sender, EventArgs e)
        {
            try
            {
                var jsonResult = await _satinalmaTeklifService.GetSatinalmaTeklif(new SatinalmaTeklifBaslik());
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult)[0];
                List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks = _jsonConverter.ToModelList<SatinalmaTeklifBaslik>(result.result);
                foreach (var item in satinalmaTeklifBasliks)
                {
                    satinalmaTeklifDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifBaslikDTO>(item));
                }
                universalGrid1.SetData(satinalmaTeklifDTOs, this.Name,true,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        private async void universalGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                universalGrid1.Grid.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex || e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)
                {
                    if (universalGrid1.Grid.Rows[e.RowIndex].Cells[1].Value == null)
                        return;
                    var satinalmaTeklifBaslikDTO = (SatinalmaTeklifBaslikDTO)universalGrid1.binding.Current;
                    SatinalmaTeklifBaslik satinalmaTeklifBaslik = ConvertHelper.ToEntity<SatinalmaTeklifBaslik>(satinalmaTeklifBaslikDTO);

                    if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Guncelle"].ColumnIndex)//Update
                    {
                        
                        SatinalmaTeklifKayitFormu satinalmaTeklifKayitFormu = FormFactory.CreateForm<SatinalmaTeklifKayitFormu>();
                        satinalmaTeklifKayitFormu.UpdateMode(satinalmaTeklifBaslik);
                        satinalmaTeklifKayitFormu.ShowDialog();
                    }
                    else if (e.ColumnIndex == universalGrid1.Grid.Rows[e.RowIndex].Cells["Sil"].ColumnIndex)//Delete
                    {
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
        private void SatinalmaTeklifTaleplerFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
        
    }
}
