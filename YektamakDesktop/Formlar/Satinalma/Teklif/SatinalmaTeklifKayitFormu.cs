using ApiService.Common;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using Utilities.Interfaces;
using YektamakDesktop.Common;

namespace YektamakDesktop.Formlar.Satinalma.Teklif
{
    public partial class SatinalmaTeklifKayitFormu : Form
    {
        private static ISatinalmaTeklifService _satinalmaTeklifService;
        private static IJsonConverter _jsonConverter;
        private static ICache _cache;
        private static IDataTableMapper _dataTableMapper;
        public SatinalmaTeklifKayitFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache, IDataTableMapper dataTableMapper)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
        }
        private SatinalmaTeklifKayitFormu()
        {
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref firmaId);
            ComboBoxListFill.GetLookupAd(_cache.dovizCinsiList, ref clbDoviz);
            ComboBoxListFill.GetLookupAd(_cache.vadeList, ref clbVade);
        }
        private static SatinalmaTeklifKayitFormu _satinalmaTeklifKayitFormu;
        public static SatinalmaTeklifKayitFormu satinalmaTeklifKayitFormu
        {
            get
            {
                if (_satinalmaTeklifKayitFormu == null || _satinalmaTeklifKayitFormu.IsDisposed)
                {
                    _satinalmaTeklifKayitFormu = new();
                    GlobalData.Yetki(ref _satinalmaTeklifKayitFormu);
                }
                return _satinalmaTeklifKayitFormu;
            }
        }
        private SatinalmaTeklifBaslik _satinalmaTeklifBaslik;
        public SatinalmaTeklifBaslik satinalmaTeklifBaslik
        {
            get
            {
                if (_satinalmaTeklifBaslik == null)
                {
                    _satinalmaTeklifBaslik = new();
                }
                return _satinalmaTeklifBaslik;
            }
            set
            {
                _satinalmaTeklifBaslik = value;
            }
        }
        private async void customButtonSave1_Click(object sender, EventArgs e)
        {
            try
            {
                List<SatinalmaTeklifBaslik> satinalmaTeklifBasliks = new();
                List<SatinalmaTeklifDetayDTO> detay = universalGrid1.binding.DataSource as List<SatinalmaTeklifDetayDTO>;
                DataTable dataTable = Common.ConvertHelper.ToDataTable(detay);
                satinalmaTeklifBaslik.satinalmaTeklifDetayList = _dataTableMapper.MapToEntityList<SatinalmaTeklifDetay>(dataTable);
                satinalmaTeklifBasliks.Add(satinalmaTeklifBaslik);
                string jsonResult = await _satinalmaTeklifService.SaveSatinalmaTeklif(satinalmaTeklifBasliks);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                if (result.result.Contains("error",StringComparison.OrdinalIgnoreCase)) 
                {
                    MessageBox.Show(result.result);
                }
                else
                {
                    var dto = SatinalmaTeklifTaleplerFormu.satinalmaTeklifTaleplerFormu.satinalmaTeklifDTOs;
                    var index = dto.FindIndex(d => d.Id == satinalmaTeklifBaslik.Id);
                    var nentity = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(result.result);
                    DataTable dataTable1 = Common.ConvertHelper.ToDataTable(nentity);
                    var ndto = _dataTableMapper.MapToEntityList<SatinalmaTeklifBaslikDTO>(dataTable1)[0];
                    dto[index] =ndto;
                    MessageBox.Show("Kayıt Başarılı");
                }

            }
            catch(Exception  ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void UpdateMode(SatinalmaTeklifBaslik satinalmaTeklifBaslik)
        {
            try
            {
                this.satinalmaTeklifBaslik = satinalmaTeklifBaslik;
                var dataTable = Common.ConvertHelper.ToDataTable(satinalmaTeklifBaslik.satinalmaTeklifDetayList);
                List<SatinalmaTeklifDetayDTO> satinalmaTeklifDetayDTOs = _dataTableMapper.MapToEntityList<SatinalmaTeklifDetayDTO>(dataTable);
                universalGrid1.SetData(satinalmaTeklifDetayDTOs, this.Name);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = satinalmaTeklifBaslik;
                ctbTeklifTalepTarihi.DataBindings.Add("TextCustom", bindingSource, "teklifTalepTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbTeklifNo.DataBindings.Add("TextCustom", bindingSource, "teklifNo", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbTeklifTarihi.DataBindings.Add("TextCustom", bindingSource, "teklifTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbTeklifGecerlilikSuresi.DataBindings.Add("TextCustom", bindingSource, "teklifGecerlilikSuresi", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbTerminSuresi.DataBindings.Add("TextCustom", bindingSource, "terminSuresi", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbTutar.DataBindings.Add("TextCustom", bindingSource, "teklifTutar.tutar", true, DataSourceUpdateMode.OnPropertyChanged);
                ctbAciklama.DataBindings.Add("TextCustom", bindingSource, "aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
                firmaId.DataBindings.Add("selectedDataRowId", bindingSource, "teklifFirma.Id", true, DataSourceUpdateMode.OnPropertyChanged);
                clbVade.DataBindings.Add("selectedDataRowId", bindingSource, "vade.Id", true, DataSourceUpdateMode.OnPropertyChanged);
                clbDoviz.DataBindings.Add("selectedDataRowId", bindingSource, "teklifTutar.dovizCinsi.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SatinalmaTeklifKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings(this.Name);
        }
    }
}
