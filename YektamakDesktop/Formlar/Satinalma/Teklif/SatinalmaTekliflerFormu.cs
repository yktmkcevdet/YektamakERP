using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Satinalma.Teklif;

namespace YektamakDesktop.Formlar.Satinalma
{
    public partial class SatinalmaTekliflerFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;
        public SatinalmaTekliflerFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            InitializeComponent();
            universalGrid1.Grid.CellClick += universalGrid1_CellClick;
            ComboBoxListFill.GetLookupKod(_cache.projes, ref clbPorjeKod);
            ComboBoxListFill.GetLookupAd(_cache.stokGrups, ref clbStokGrup);
            ComboBoxListFill.GetLookupAd(_cache.malzemeGrups, ref clbMalzemeGrup);
            Load +=async(s,e)=>await SatinalmaTeklifTaleplerFormu_Load(s,e);
            FormClosing += async (s, e) => await SatinalmaTeklifTaleplerFormu_FormClosing(s,e);
        }
        private List<SatinalmaTeklifBaslikDTO> _satinalmaTeklifDTOs;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        private async Task SatinalmaTeklifTaleplerFormu_Load(object sender, EventArgs e)
        {
            try
            {
                SatinalmaTeklifBaslik satinalmaTeklifBaslik = new SatinalmaTeklifBaslik();
                var jsonResult = await _satinalmaTeklifService.GetSatinalmaTeklif(new SatinalmaTeklifBaslik());
                List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(jsonResult);
                foreach (var item in satinalmaTeklifBasliks.Where(x=>x.teklifTutar.tutar>0))
                {
                    satinalmaTeklifDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifBaslikDTO>(item));
                }
                await universalGrid1.SetData(satinalmaTeklifDTOs, this.Name,true);
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
                        MessageBox.Show(jsonResult);
                        universalGrid1.binding.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

        }
        private async Task SatinalmaTeklifTaleplerFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }
        
    }
}
