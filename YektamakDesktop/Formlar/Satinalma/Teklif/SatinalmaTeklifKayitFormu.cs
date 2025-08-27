using ApiService.Interfaces;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar.Satinalma.Siparis;

namespace YektamakDesktop.Formlar.Satinalma.Teklif
{
    public partial class SatinalmaTeklifKayitFormu : Form
    {
        private readonly ISatinalmaTeklifService _satinalmaTeklifService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICache _cache;
        private readonly IDataTableMapper _dataTableMapper;
        public SatinalmaTeklifKayitFormu(ISatinalmaTeklifService satinalmaTeklifService,  IJsonConverter jsonConverter, ICache cache, IDataTableMapper dataTableMapper)
        {
            _satinalmaTeklifService = satinalmaTeklifService;
            _jsonConverter = jsonConverter;
            _cache = cache;
            _dataTableMapper = dataTableMapper;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Controls.Remove(universalGrid1);
            universalGrid1 = DIContainer.GetService<UniversalGrid>();
            universalGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            universalGrid1.Location = new System.Drawing.Point(54, 378);
            universalGrid1.Name = "universalGrid1";
            universalGrid1.Size = new System.Drawing.Size(824, 364);
            universalGrid1.TabIndex = 17;
            Controls.Add(universalGrid1);
            fcbFirma.SetDataSource(_cache.firmaList);
            clbDoviz.SetDataSource(_cache.dovizCinsiList);
            clbVade.SetDataSource(_cache.vadeList);
        }
        private SatinalmaTeklifBaslik _satinalmaTeklifBaslik;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            if(!ValidateForm())
            {
                return;
            }
            try
            {
                SortableBindingList<SatinalmaTeklifDetayDTO> detay = (SortableBindingList<SatinalmaTeklifDetayDTO>)universalGrid1.binding.DataSource;
                satinalmaTeklifBaslik.satinalmaTeklifDetayList.Clear();
                foreach (var item in detay)
                {
                    satinalmaTeklifBaslik.satinalmaTeklifDetayList.Add(ConvertHelper.ToEntity<SatinalmaTeklifDetay>(item));
                }
                string jsonResult = await _satinalmaTeklifService.SaveSatinalmaTeklif(satinalmaTeklifBaslik);
                if (String.IsNullOrEmpty(jsonResult) || jsonResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(jsonResult);
                }
                else
                {
                    var nentity = JsonConvert.DeserializeObject<List<SatinalmaTeklifBaslik>>(jsonResult);
                    MessageBox.Show("Kayıt Başarılı");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool ValidateForm()
        {
            bool result = true;
            result &= GlobalData.CheckField("Firma Seçiniz",fcbFirma);
            result &= GlobalData.CheckField("Teklif Tarihi Giriniz", ctbTeklifTarihi);
            result &= GlobalData.CheckField("Teklif Talep Tarihi Giriniz", ctbTeklifTalepTarihi);
            result &= GlobalData.CheckField("*", clbDoviz);
            result &= GlobalData.CheckField("Teklif Tutarı Giriniz", ctbTutar);
            result &= GlobalData.CheckField("Teklif Geçerlilik Süresi Giriniz", ctbTeklifGecerlilikSuresi);
            result &= GlobalData.CheckField("Termin Süresi Giriniz", ctbTerminSuresi);
            result &= GlobalData.CheckField("*", clbVade);
            return result;
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
            BindHelper.BindData(ctbTeklifNo, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifNo));
            BindHelper.BindData(fcbFirma, satinalmaTeklifBaslik.teklifFirma, nameof(satinalmaTeklifBaslik.teklifFirma.Id));
            BindHelper.BindData(ctbTeklifTalepTarihi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTalepTarihi));
            BindHelper.BindData(ctbTerminSuresi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.terminSuresi));
            BindHelper.BindData(ctbTeklifTarihi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTarihi));
            BindHelper.BindData(clbVade, satinalmaTeklifBaslik.vade, nameof(satinalmaTeklifBaslik.vade.Id));
            BindHelper.BindData(ctbTutar, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifTutar));
            BindHelper.BindData(clbDoviz, satinalmaTeklifBaslik.dovizCinsi, nameof(satinalmaTeklifBaslik.dovizCinsi.Id));
            BindHelper.BindData(ctbTeklifGecerlilikSuresi, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.teklifGecerlilikSuresi));
            BindHelper.BindData(ctbAciklama, satinalmaTeklifBaslik, nameof(satinalmaTeklifBaslik.aciklama));

            List<SatinalmaTeklifDetayDTO> satinalmaTeklifDetayDTOs = new();
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                satinalmaTeklifDetayDTOs.Add(ConvertHelper.ToDTO<SatinalmaTeklifDetayDTO>(item));
            }
            await universalGrid1.SetData(satinalmaTeklifDetayDTOs, this.Name);
        }

        private async void SatinalmaTeklifKayitFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            await universalGrid1.SaveSettings();
        }

        private async void btnSipariseDonustur_Click(object sender, EventArgs e)
        {
            if(!ValidateForm())
            {
                return;
            }
            SatinalmaSiparis satinalmaSiparis = new SatinalmaSiparis();
            satinalmaSiparis.siparisTarihi = DateTime.Today;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.firma = satinalmaTeklifBaslik.teklifFirma;
            satinalmaSiparis.aciklama = satinalmaTeklifBaslik.aciklama;
            satinalmaSiparis.vade = satinalmaTeklifBaslik.vade;
            satinalmaSiparis.satinalmaTeklif.Id = satinalmaTeklifBaslik.Id;
            satinalmaSiparis.tutar = satinalmaTeklifBaslik.teklifTutar;
            satinalmaSiparis.dovizCinsi = satinalmaTeklifBaslik.dovizCinsi;
            foreach (var item in satinalmaTeklifBaslik.satinalmaTeklifDetayList)
            {
                SatinalmaSiparisDetay satinalmaSiparisDetay = new SatinalmaSiparisDetay();
                satinalmaSiparisDetay.miktar = item.satinalmaTalepDetay.miktar;
                satinalmaSiparisDetay.aciklama = item.satinalmaTalepDetay.aciklama;
                satinalmaSiparisDetay.birimFiyat = item.birimFiyat;
                satinalmaSiparisDetay.stokKartId = item.satinalmaTalepDetay.stokKart.Id;
                satinalmaSiparis.satinalmaSiparisDetayList.Add( satinalmaSiparisDetay );
            }
            var satinalmaSiparisKayitFormu = FormFactory.CreateForm<SatinalmaSiparisKayitFormu>();
            satinalmaSiparisKayitFormu.UpdateMode(satinalmaSiparis);
            satinalmaSiparisKayitFormu.ShowDialog();
        }
    }
}
