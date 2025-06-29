using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop.Formlar.Satis
{
    public partial class SatisTeklifMaliyetKayitFormu : Form, IForm
    {
        private static ICache _cache;
        private static ISatisService _satisService;
        private static IJsonConverter _jsonConvertHelper;
        private static IDataTableMapper _dataTableHelper;
        public SatisTeklifMaliyetKayitFormu(ICache cache,ISatisService satisService, IJsonConverter jsonConvertHelper,IDataTableMapper dataTableHelper)
        {
            _cache = cache;
            _satisService = satisService;
            _jsonConvertHelper = jsonConvertHelper;
            _dataTableHelper = dataTableHelper;
        }
        private SatisTeklifTalep _satisTeklifTalep;
        public SatisTeklifTalep satisTeklifTalep
        {
            get
            {
                if (_satisTeklifTalep == null) _satisTeklifTalep = new SatisTeklifTalep();
                return _satisTeklifTalep;
            }
            set { _satisTeklifTalep = value; }
        }
        private static SatisTeklifMaliyetKayitFormu _satisTeklifMaliyetKayitFormu;
        public static SatisTeklifMaliyetKayitFormu satisTeklifMaliyetKayitFormu
        {
            get
            {
                if (_satisTeklifMaliyetKayitFormu == null)
                {
                    _satisTeklifMaliyetKayitFormu = new SatisTeklifMaliyetKayitFormu();
                    GlobalData.Yetki(ref _satisTeklifMaliyetKayitFormu);
                }
                return _satisTeklifMaliyetKayitFormu;
            }
            set
            {
                _satisTeklifMaliyetKayitFormu = value;
            }
        }

        private List<Control> _controlsToDisable;
        public List<Control> controlsToDisable { get => _controlsToDisable; set => _controlsToDisable = value; }
        private bool _activeForm;
        public bool activeForm { get => _activeForm; set => _activeForm = value; }

        private SatisTeklifMaliyetKayitFormu()
        {
            InitializeComponent();
            customDataGrid = new CustomDataGrid<DataControlTeklifMaliyetDetay>(2, 30, new Point(5, 5), new Size(700, 250));
            ComboBoxListFill.GetLookupAd(_cache.firmaList, ref musteriId);
            ComboBoxListFill.GetLookupAd(_cache.markaList, ref markaId);
            ComboBoxListFill.GetLookupAd(_cache.markaAltGrupList, ref altGrupId);
            ComboBoxListFill.GetLookupAd(_cache.referansKaynakList, ref referansKaynakId);
            ComboBoxListFill.GetLookupAd(_cache.personelList, ref satisSorumlusuId);
            panel1.Controls.Add(customDataGrid.headerPanel);
            panel1.Controls.Add(customDataGrid.detailPanel);
            controlsToDisable = new List<Control>();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        public void CloseForm()
        {
            GlobalData.CloseForm(ref _satisTeklifMaliyetKayitFormu);
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SatisTeklifMaliyetKayitFormu_Load(object sender, EventArgs e)
        {
            teklifTalepId.TextCustom = _satisTeklifTalep.Id.ToString();
            teklifTalepTarihi.TextCustom = _satisTeklifTalep.teklifTalepTarihi;
            musteriId.SelectDataRowId(_satisTeklifTalep.musteri.Id??-1);
            teklifKonusu.TextCustom = _satisTeklifTalep.teklifKonusu;
            markaId.SelectDataRowId(_satisTeklifTalep.marka.Id);
            altGrupId.SelectDataRowId(_satisTeklifTalep.altGrup.Id);
            referansKaynakId.SelectDataRowId(_satisTeklifTalep.referansKaynakId);
            satisSorumlusuId.SelectDataRowId(_satisTeklifTalep.satisSorumlusu.Id??-1);
            List<DataControlTeklifMaliyetDetay> customDataGridList = new List<DataControlTeklifMaliyetDetay>();
            foreach (var item in _satisTeklifTalep.satisTeklifMaliyetList)
            {
                DataControlTeklifMaliyetDetay dataControlTeklifMaliyetDetay = new DataControlTeklifMaliyetDetay();
                dataControlTeklifMaliyetDetay.teklifTalepMaliyetId.TextCustom = item.Id.ToString();
                dataControlTeklifMaliyetDetay.teklifTalepMaliyetUnsurId.SelectDataRowId(item.maliyetUnsurId);
                dataControlTeklifMaliyetDetay.teklifTalepMaliyetTespitKanalId.SelectDataRowId(item.maliyetTespitKanali);
                dataControlTeklifMaliyetDetay.dosyaVeri = item.belge;
                dataControlTeklifMaliyetDetay.teklifTalepId.TextCustom = item.teklifTalepId.ToString();
                dataControlTeklifMaliyetDetay.ongorulenMaliyet.TextCustom = item.maliyetTutar.ToString();
                dataControlTeklifMaliyetDetay.ongorulenMaliyetDovizCinsiId.SelectDataRowId(item.dovizCinsiId);
                customDataGridList.Add(dataControlTeklifMaliyetDetay);
            }
            customDataGrid.dataSource = customDataGridList;
            satisTeklifTalep = currentData;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _satisTeklifTalep = currentData;
            string result = await _satisService.SaveSatisSiparisTeklifTalep(_satisTeklifTalep);
            if (result.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(result);
            }
            else
            {
                _satisTeklifTalep = _dataTableHelper.MapToEntity<SatisTeklifTalep>(_jsonConvertHelper.DeserializeToDataSet(result).Tables[0].Rows[0]);
                teklifTalepId.TextCustom = satisTeklifTalep.Id.ToString();
                _satisTeklifTalep = currentData;
                byte[] msg = JsonConvert.DeserializeObject<byte[]>(result);
                string mesaj = Encoding.UTF8.GetString(msg);
                string formattedJson = JsonConvert.SerializeObject(
                                        JsonConvert.DeserializeObject(mesaj),
                                        Formatting.Indented
                                        );
                MessageBox.Show(formattedJson.Substring(1,1000));
            }
        }

        private SatisTeklifTalep currentData
        {
            get
            {
                SatisTeklifTalep satisTeklifTalep = new SatisTeklifTalep();

                satisTeklifTalep.Id = Convert.ToInt32(teklifTalepId.TextCustom);
                string s = _satisService.GetSatisTeklifTalep(satisTeklifTalep);
                satisTeklifTalep.belgeList = _dataTableHelper.MapToEntity<SatisTeklifTalep>(_jsonConvertHelper.DeserializeToDataSet(s).Tables[0].Rows[0]).belgeList;
                satisTeklifTalep.teklifTalepTarihi = Convert.ToDateTime(teklifTalepTarihi.TextCustom);
                satisTeklifTalep.musteri.Id = musteriId.selectedDataRowId;
                satisTeklifTalep.teklifKonusu = teklifKonusu.TextCustom;
                satisTeklifTalep.marka.Id = markaId.selectedDataRowId;
                satisTeklifTalep.altGrup.Id = altGrupId.selectedDataRowId;
                satisTeklifTalep.referansKaynakId = referansKaynakId.selectedDataRowId;
                satisTeklifTalep.satisSorumlusu.Id = satisSorumlusuId.selectedDataRowId;

                foreach (DataControlTeklifMaliyetDetay item in customDataGrid.dataSource.Where(x => x.newRec == false))
                {
                    SatisTeklifMaliyet belge = new SatisTeklifMaliyet();
                    belge.Id = Int32.TryParse(item.teklifTalepMaliyetId.TextCustom, out int id) ? id : 0;
                    belge.teklifTalepId = Int32.TryParse(item.teklifTalepId.TextCustom,out int teklifTalepId)?teklifTalepId:0;
                    belge.maliyetUnsurId = item.teklifTalepMaliyetUnsurId.selectedDataRowId;
                    belge.maliyetTespitKanali = item.teklifTalepMaliyetUnsurId.selectedDataRowId;
                    belge.maliyetTutar = Convert.ToDouble(item.ongorulenMaliyet.TextCustom);
                    belge.dovizCinsiId = Convert.ToInt32(item.teklifTalepMaliyetUnsurId.selectedDataRowId);
                    belge.belge = item.dosyaVeri;
                    satisTeklifTalep.satisTeklifMaliyetList.Add(belge);
                }
                return satisTeklifTalep;
            }
        }
    }
}
