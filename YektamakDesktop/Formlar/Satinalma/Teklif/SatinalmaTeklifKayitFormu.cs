using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satinalma.Teklif
{
    public partial class SatinalmaTeklifKayitFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableMapper;
        public SatinalmaTeklifKayitFormu(ISatinalmaTeklifService satinalmaTeklifService, IJsonConverter jsonConverter, ICache cache, IDataTableMapper dataTableMapper)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
            InitializeComponent();
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref firmaId);
            ComboBoxListFill.GetLookupAd(_cache.dovizCinsiList, ref clbDoviz);
            ComboBoxListFill.GetLookupAd(_cache.vadeList, ref clbVade);
            universalGrid1.kullanici = _cache.kullanici;
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
                Binding();
            }
        }
        private async void customButtonSave1_Click(object sender, EventArgs e)
        {
            try
            {
                SortableBindingList<SatinalmaTeklifDetayDTO> detay = (SortableBindingList<SatinalmaTeklifDetayDTO>)universalGrid1.binding.DataSource;
                satinalmaTeklifBaslik.satinalmaTeklifDetayList.Clear();
                foreach (var item in detay)
                {
                    satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(ConvertHelper.ToEntity<SatinalmaTeklifDetay>(item));
                }
                string jsonResult = await _satinalmaTeklifService.SaveSatinalmaTeklif(satinalmaTeklifBaslik);
                Result result = _jsonConverter.DeserializeToModelList<Result>(jsonResult).FirstOrDefault();
                if (result.result.Contains("error",StringComparison.OrdinalIgnoreCase)) 
                {
                    MessageBox.Show(result.result);
                }
                else
                {
                    var nentity = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(result.result);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Binding()
        {
            ctbTeklifTalepTarihi.DataBindings.Clear();
            ctbTeklifNo.DataBindings.Clear();
            ctbTeklifTarihi.DataBindings.Clear();
            ctbTeklifGecerlilikSuresi.DataBindings.Clear();
            ctbTerminSuresi.DataBindings.Clear();
            ctbTutar.DataBindings.Clear();
            ctbAciklama.DataBindings.Clear();
            firmaId.DataBindings.Clear();
            clbVade.DataBindings.Clear();
            clbDoviz.DataBindings.Clear();
            ctbTeklifTalepTarihi.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "teklifTalepTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeklifNo.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "teklifNo", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeklifTarihi.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "teklifTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTeklifGecerlilikSuresi.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "teklifGecerlilikSuresi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTerminSuresi.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "terminSuresi", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbTutar.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "teklifTutar.tutar", true, DataSourceUpdateMode.OnPropertyChanged);
            ctbAciklama.DataBindings.Add("TextCustom", satinalmaTeklifBaslik, "aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
            firmaId.DataBindings.Add("selectedDataRowId", satinalmaTeklifBaslik, "teklifFirma.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbVade.DataBindings.Add("selectedDataRowId", satinalmaTeklifBaslik, "vade.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            clbDoviz.DataBindings.Add("selectedDataRowId", satinalmaTeklifBaslik, "teklifTutar.dovizCinsi.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            List<SatinalmaTeklifDetayDTO> satinalmaTeklifDetayDTOs = new();
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                satinalmaTeklifDetayDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifDetayDTO>(item));
            }
            await universalGrid1.SetData(satinalmaTeklifDetayDTOs, this.Name);
        }

        private void SatinalmaTeklifKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveSettings();
        }
    }
}
