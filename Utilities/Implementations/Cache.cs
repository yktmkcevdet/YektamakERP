using ApiService;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using System.Data;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class Cache : ICache
    {
        private readonly IJsonConverter JsonConverter;
        private readonly IDataTableMapper DataTableConverter;
        private readonly IProjeService _projeService;
        private readonly IStokService _stokService;
        private readonly IKullaniciYetkiService _kullaniciYetki;
        private readonly IFirmaService _firmaService;
        private readonly IPersonelService _personelService;
        private readonly ISatisService _satisService;
        private readonly IDovizCinsiService _dovizCinsiService;
        private readonly IMaliyetService _maliyetService;
        private readonly IAnaVeriService _anaVeriService;
        private readonly IVadeService _vadeService;
        public Cache(IJsonConverter jsonConverter, IDataTableMapper dataTableConverter, IProjeService projeService, 
            IStokService stokService,IKullaniciYetkiService kullaniciYetki,IFirmaService firmaService,IPersonelService personelService,ISatisService satisService,
            IDovizCinsiService dovizCinsiService,IMaliyetService maliyetService,IAnaVeriService anaVeriService, IVadeService vadeService)
        {
            JsonConverter = jsonConverter;
            DataTableConverter = dataTableConverter;
            _projeService = projeService;
            _stokService = stokService;
            _kullaniciYetki = kullaniciYetki;
            _firmaService = firmaService;
            _personelService = personelService;
            _satisService = satisService;
            _dovizCinsiService = dovizCinsiService;
            _maliyetService = maliyetService;
            _anaVeriService = anaVeriService;
            _vadeService = vadeService;
        }
        private Models.Kullanici _kullanici;
        public Models.Kullanici kullanici
        {
            get
            {
                if (_kullanici == null)
                {
                    _kullanici = new Models.Kullanici();
                }
                return _kullanici;
            }
            set
            {
                _kullanici = value;
            }
        }
        private List<Kullanici> _kullaniciList;
        public async Task<List<Kullanici>> kullaniciListAsync()
        {
            if (_kullaniciList == null || _kullaniciList.Count == 0)
            {
                _kullaniciList = await GetModelListAsync<Kullanici>(async () => { return await _kullaniciYetki.GetKullaniciAsync(new Kullanici()); });
            }
            return _kullaniciList;
            
        }
        public List<Kullanici> kullaniciList
        {
            get
            {
                if (_kullaniciList == null)
                {
                    _kullaniciList = GetModelList(_kullaniciYetki.GetKullanici, new Models.Kullanici());
                }
                else if (_kullaniciList.Count == 0)
                {
                    _kullaniciList = GetModelList(_kullaniciYetki.GetKullanici, new Models.Kullanici());
                }
                return _kullaniciList;
            }
        }
        private List<Rol> _rolList;
        public List<Rol> rolList
        {
            get
            {
                if (_rolList == null)
                {
                    _rolList = GetModelList(_kullaniciYetki.GetRol, new Rol());
                }
                else if (_rolList.Count == 0)
                {
                    _rolList = GetModelList(_kullaniciYetki.GetRol, new Rol());
                }
                return _rolList;
            }
        }
        private AnaMenuDTO anaMenu
        {
            get
            {
                return new AnaMenuDTO { rolId = kullanici.rol.Id??0 };
            }
        }
        private Menu menu
        {
            get
            {
                return new Menu();
            }
        }
        private List<AnaMenuDTO> _anaMenuList;
        public List<AnaMenuDTO> ananaMenuList
        {
            get
            {
                if (_anaMenuList == null)
                {
                    _anaMenuList = GetModelList(_kullaniciYetki.GetAnaMenu, anaMenu);
                }
                else if (_anaMenuList.Count == 0)
                {
                    _anaMenuList = GetModelList(_kullaniciYetki.GetAnaMenu, anaMenu);
                }
                return _anaMenuList;
            }
        }
        private List<Menu> _menuList;
        public List<Menu> menuList
        {
            get
            {
                if (_menuList == null)
                {
                    _menuList = GetModelList(_kullaniciYetki.GetMenu, menu);
                }
                else if (_menuList.Count == 0)
                {
                    _menuList = GetModelList(_kullaniciYetki.GetMenu, menu);
                }
                return _menuList;
            }
        }
        private Yetki yetki
        {
            get { return new Yetki { rolId = kullanici.rol.Id ?? 0 }; }
        }
        private List<Yetki> _yetkiList;
        public List<Yetki> yetkiList
        {
            get
            {
                if (_yetkiList == null)
                {
                    _yetkiList = GetModelList(_kullaniciYetki.GetYetki, yetki);
                }
                return _yetkiList;
            }
        }
        private List<StokGrup> _stokGrups;
        public List<StokGrup> stokGrups
        {
            get
            {
                if (_stokGrups == null)
                {
                    _stokGrups = GetModelList(_stokService.GetStokGrup, new StokGrup());
                }
                return _stokGrups;
            }
        }
        private List<MalzemeGrup> _parcaGrups;
        public List<MalzemeGrup> malzemeGrups
        {
            get
            {
                if (_parcaGrups == null)
                {
                    _parcaGrups = GetModelList(_stokService.GetMalzemeGrup, new MalzemeGrup());
                }
                return _parcaGrups;
            }
        }
        private List<MalzemeAltGrup> _malzemeAltGrups;
        public List<MalzemeAltGrup> malzemeAltGrups
        {
            get
            {
                if (_malzemeAltGrups == null)
                {
                    _malzemeAltGrups = GetModelList(_stokService.GetMalzemeAltGrup, new MalzemeAltGrup());
                }
                return _malzemeAltGrups;
            }
        }
        private List<MalzemeAltGrup2> _malzemeAltGrup2s;
        public List<MalzemeAltGrup2> malzemeAltGrup2List
        {
            get
            {
                if (_malzemeAltGrup2s == null)
                {
                    _malzemeAltGrup2s = GetModelList(_stokService.GetMalzemeAltGrup2, new MalzemeAltGrup2());
                }
                return _malzemeAltGrup2s;
            }
        }
        private List<StokTip> _stokTips;
        public List<StokTip> stokTips
        {
            get
            {
                if (_stokTips == null)
                {
                    _stokTips = GetModelList(_stokService.GetStokTip, new StokTip());
                }
                return _stokTips;
            }
        }
        private List<ProfilTip> _profilTips;
        public List<ProfilTip> profilTips
        {
            get
            {
                if (_profilTips == null)
                {
                    _profilTips = GetModelList(_stokService.GetProfilTip, new ProfilTip());
                }
                return _profilTips;
            }
        }
        private List<OlcuBirim> _olcuBirims;
        public List<OlcuBirim> olcuBirims
        {
            get
            {
                if (_olcuBirims == null)
                {
                    _olcuBirims = GetModelList(_stokService.GetOlcuBirim, new OlcuBirim());
                }
                return _olcuBirims;
            }
        }
        
        private List<MalzemeStandart> _malzemeStandarts;
        public List<MalzemeStandart> malzemeStandarts
        {
            get
            {
                if (_malzemeStandarts == null)
                {
                    _malzemeStandarts = GetModelList(_stokService.GetMalzemeStandart, new MalzemeStandart());
                }
                return _malzemeStandarts;
            }
        }
        private List<Proje> _projes;
        public List<Proje> projes
        {
            get
            {
                if (_projes == null)
                {
                    _projes = GetModelList(_projeService.GetProje, new Proje());
                }
                return _projes;
            }
        }
        private List<Proje> _unAssignedProjeList;
        public List<Proje> unAssignedProjeList
        {
            get
            {
                if (_unAssignedProjeList == null)
                {
                    _unAssignedProjeList = GetModelList(_projeService.GetProje, new Proje()).Where(x => x.satisSiparisId == 0).ToList();
                }
                return _unAssignedProjeList;
            }
        }
        private List<Sektor> _sektorList;
        public List<Sektor> sektorList
        {
            get
            {
                if (_sektorList == null)
                {
                    _sektorList = GetModelList(_firmaService.GetSektor, new Sektor());
                }
                return _sektorList;
            }
        }
        public List<T> GetModelList<T>(Func<T, string> fetchFunction, T t) where T : IEntity, new()
        {
            var jsonResult = fetchFunction.Invoke(t);
            List<T> list = JsonConverter.DeserializeToModelList<T>(jsonResult);
            return list;
        }
        public List<T> GetModelList<T>(Func<string> fetchFunction) where T : IEntity, new()
        {
            var jsonResult = fetchFunction.Invoke();
            List<T> list = JsonConverter.DeserializeToModelList<T>(jsonResult);
            return list;
        }
        public async Task<List<T>> GetModelListAsync<T>(Func<Task<string>> fetchFunction) where T : IEntity, new()
        {
            var jsonResult = await fetchFunction();
            List<T> list = JsonConverter.DeserializeToModelList<T>(jsonResult);
            return list;
        }
        private List<Firma> _firmaList;
        public List<Firma> firmaList
        {
            get
            {
                if (_firmaList == null)
                {
                    _firmaList = GetModelList<Firma>(_firmaService.GetFirma,new Firma());
                }
                return _firmaList;
            }
        }
        private List<Personel> _personelList;
        public List<Personel> personelList
        {
            get
            {
                if (_personelList == null)
                {
                    _personelList = GetModelList(_personelService.GetPersonel, new Personel());
                }
                return _personelList;
            }
        }
        private List<Marka> _markaList;
        public List<Marka> markaList
        {
            get
            {
                if (_markaList == null)
                {
                    _markaList = GetModelList<Marka>(_projeService.GetMarka);
                }
                return _markaList;
            }
        }
        private List<MarkaAltGrup> _markaAltGrupList;
        public List<MarkaAltGrup> markaAltGrupList
        {
            get
            {
                if (_markaAltGrupList == null)
                {
                    _markaAltGrupList = GetModelList<MarkaAltGrup>(_projeService.GetMarkaAltGrup);
                }
                return _markaAltGrupList;
            }
        }
        private List<ReferansKaynak> _referansKaynakList;
        public List<ReferansKaynak> referansKaynakList
        {
            get
            {
                if (_referansKaynakList == null)
                {
                    _referansKaynakList = GetModelList<ReferansKaynak>(_satisService.GetReferansKaynak);
                }
                return _referansKaynakList;
            }
        }
        private List<DovizCinsi> _dovizCinsiList;
        public List<DovizCinsi> dovizCinsiList
        {
            get
            {
                if (_dovizCinsiList == null)
                {
                    _dovizCinsiList = GetModelList<DovizCinsi>(_dovizCinsiService.GetDovizCinsi);
                }
                return _dovizCinsiList;
            }
        }
        private List<Vade> _vadeList;
        public List<Vade> vadeList
        {
            get
            {
                if (_vadeList == null)
                {
                    _vadeList = GetModelList<Vade>(_vadeService.GetVade);
                }
                return _vadeList;
            }
        }
        private List<MaliyetUnsur> _maliyetUnsurList;
        public List<MaliyetUnsur> maliyetUnsurList
        {
            get
            {
                if (_maliyetUnsurList == null)
                {
                    _maliyetUnsurList = GetModelList<MaliyetUnsur>(_maliyetService.GetMaliyetUnsur);
                }
                return _maliyetUnsurList;
            }
            set
            {
                _maliyetUnsurList = value;
            }
        }
        private List<MaliyetTespitKanal> _maliyetTespitKanalList;
        public List<MaliyetTespitKanal> maliyetTespitKanalList
        {
            get
            {
                if (_maliyetTespitKanalList == null)
                {
                    _maliyetTespitKanalList = GetModelList<MaliyetTespitKanal>(_maliyetService.GetMaliyetTespitKanal);
                }
                return _maliyetTespitKanalList;
            }
            set
            {
                _maliyetTespitKanalList = value;
            }
        }
        private List<DosyaTip> _dosyaTipList;
        public List<DosyaTip> dosyaTipList
        {
            get
            {
                if (_dosyaTipList == null)
                {
                    _dosyaTipList = GetModelList<DosyaTip>(_anaVeriService.GetDosyaTip);
                }
                return _dosyaTipList;
            }
            set
            {
                _dosyaTipList = value;
            }
        }
    }
}
