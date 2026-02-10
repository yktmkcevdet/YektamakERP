using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models.Satinalma;
using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Helpers;

namespace YektamakDesktop.Formlar.Satinalma.İrsaliye
{
    public partial class MalzemeGirisFormu : Form
    {
        private readonly ICache _cache;
        private readonly ISatinalmaSiparisService _satinalmaSiparisService;
        private readonly ISatinalmaIrsaliyeService _satinalmaIrsaliyeService;
        private readonly IConvertHelper _convertHelper;
        public MalzemeGirisFormu(ICache cache, ISatinalmaSiparisService satinalmaSiparisService, IConvertHelper convertHelper, ISatinalmaIrsaliyeService satinalmaIrsaliyeService)
        {
            _convertHelper = convertHelper;
            _cache = cache;
            _satinalmaSiparisService = satinalmaSiparisService;
            _satinalmaIrsaliyeService = satinalmaIrsaliyeService;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            UniversalGridHelper.Replace(ref universalGrid1, this);
            universalGrid1.SetData(new List<SatinalmaIrsaliyeDetayDTO>(), this.Name);
            fcbFirma.SetDataSource(_cache.firmaList);
            fcbProjeKodu.SetDataSource(_cache.projeList);
            fcbStokGrup.SetDataSource(_cache.stokGrups);
        }
        private SatinalmaIrsaliyeBaslik _satinalmaIrsaliyeBaslik;
        private SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik
        {
            get
            {
                if (_satinalmaIrsaliyeBaslik == null) { _satinalmaIrsaliyeBaslik = new(); Binding(); }
                return _satinalmaIrsaliyeBaslik;
            }
            set { _satinalmaIrsaliyeBaslik = value; Binding(); }
        }
        private async void GirisFormu_Load(object sender, EventArgs e)
        {
        }

        private async Task GridLoad()
        {
            List<SatinalmaIrsaliyeDetayDTO> satinalmaIrsaliyeDetayDTOs = new List<SatinalmaIrsaliyeDetayDTO>();
            SatinalmaSiparis satinalmaSiparis1 = new SatinalmaSiparis();
            satinalmaSiparis1.firma.Id = satinalmaIrsaliyeBaslik.firma.Id;
            satinalmaSiparis1.proje.Id = satinalmaIrsaliyeBaslik.proje.Id;
            satinalmaSiparis1.malzemeGrup.Id = satinalmaIrsaliyeBaslik.malzemeGrup.Id;
            var satinalmaSiparisList = await _satinalmaSiparisService.GetSatinalmaSiparisAsync(satinalmaSiparis1);
            foreach (var satinalmaSiparis in satinalmaSiparisList)
            {
                foreach (var satinalmaSiparisDetay in satinalmaSiparis.satinalmaSiparisDetay)
                {
                    SatinalmaIrsaliyeDetayDTO satinalmaIrsaliyeDetayDTO = new SatinalmaIrsaliyeDetayDTO();
                    satinalmaIrsaliyeDetayDTO.satinalmaSiparisDetayMiktar = satinalmaSiparisDetay.miktar;
                    satinalmaIrsaliyeDetayDTO.satinalmaSiparisDetayId = satinalmaSiparisDetay.Id;
                    satinalmaIrsaliyeDetayDTO.projeStokKartId = satinalmaSiparisDetay.projeStokKart.Id;
                    satinalmaIrsaliyeDetayDTO.projeStokKartstokKartkod = satinalmaSiparisDetay.projeStokKart.stokKart.kod;
                    satinalmaIrsaliyeDetayDTO.projeStokKartstokKartad = satinalmaSiparisDetay.projeStokKart.stokKart.ad;
                    satinalmaIrsaliyeDetayDTO.satinalmaSiparisprojeStokKartstokKartolcuBrimId = satinalmaSiparisDetay.projeStokKart.stokKart.olcuBirim.Id;
                    satinalmaIrsaliyeDetayDTOs.Add(satinalmaIrsaliyeDetayDTO);
                }
            }
            await universalGrid1.SetData(satinalmaIrsaliyeDetayDTOs, this.Name);
        }

        private void Binding()
        {
            BindHelper.BindData(ctbId, satinalmaIrsaliyeBaslik, nameof(satinalmaIrsaliyeBaslik.Id));
            BindHelper.BindData(ctbIrsaliyeNo, satinalmaIrsaliyeBaslik, nameof(satinalmaIrsaliyeBaslik.irsaliyeNo));
            BindHelper.BindData(ctbTarih, satinalmaIrsaliyeBaslik, nameof(satinalmaIrsaliyeBaslik.tarih));
            BindHelper.BindData(fcbFirma, satinalmaIrsaliyeBaslik.firma, nameof(satinalmaIrsaliyeBaslik.firma.Id));
            BindHelper.BindData(fcbStokGrup, satinalmaIrsaliyeBaslik.stokGrup, nameof(satinalmaIrsaliyeBaslik.stokGrup.Id));
            BindHelper.BindData(fcbMalzemeGrup, satinalmaIrsaliyeBaslik.malzemeGrup, nameof(satinalmaIrsaliyeBaslik.malzemeGrup.Id));
            BindHelper.BindData(fcbProjeKodu, satinalmaIrsaliyeBaslik.proje, nameof(satinalmaIrsaliyeBaslik.proje.Id));
        }

        private void MalzemeGirisFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            universalGrid1.SaveGridSettings();
        }

        private void fcbFirma_SelectedValueChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ctbId.TextCustom)) GridLoad();
        }

        private async void customButtonSave1_Click(object sender, EventArgs e)
        {
            var satinalmaIrsaliyeDetayDTOs = (SortableBindingList<SatinalmaIrsaliyeDetayDTO>)universalGrid1.binding.DataSource;
            satinalmaIrsaliyeBaslik.satinalmaIrsaliyeDetayList = satinalmaIrsaliyeDetayDTOs.CastToEntity<SatinalmaIrsaliyeDetay>(_convertHelper).ToList();
            var jsonstring = await _satinalmaIrsaliyeService.SaveSatinalmaIrsaliye(satinalmaIrsaliyeBaslik);
        }

        private void fcbStokGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stokGrupId = int.Parse(fcbStokGrup.SelectedValue.ToString());
            fcbMalzemeGrup.SetDataSource(_cache.malzemeGrups.Where(m => m.stokGrup.Id == stokGrupId).ToList());
        }

        private async void ctbIrsaliyeNo_Leave(object sender, EventArgs e)
        {
            satinalmaIrsaliyeBaslik = (await _satinalmaIrsaliyeService.GetSatinalmaIrsaliye(satinalmaIrsaliyeBaslik)).FirstOrDefault();
            universalGrid1.SetData(satinalmaIrsaliyeBaslik.satinalmaIrsaliyeDetayList.CastToDTO<SatinalmaIrsaliyeDetayDTO>(_convertHelper).ToList(),this.Name);
        }
    }
}
