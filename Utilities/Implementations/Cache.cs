using ApiService;
using Models;
using Models.DTO;
using System.Data;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class Cache : ICache
    {
        private readonly IJsonConvertHelper JsonConverter;
        private readonly IDataTableHelper DataTableConverter;
        public Cache(IJsonConvertHelper jsonConverter, IDataTableHelper dataTableConverter)
        {
            JsonConverter = jsonConverter;
            DataTableConverter = dataTableConverter;
        }
        private Kullanici _kullanici;
        public Kullanici kullanici
        {
            get
            {
                if (_kullanici == null)
                {
                    _kullanici = new Kullanici();
                }
                return _kullanici;
            }
            set
            {
                _kullanici = value;
            }
        }
        private AnaMenu anaMenu
        {
            get
            {
                return new AnaMenu { rolId = kullanici.rolId };
            }
        }
        private Menu menu
        {
            get
            {
                return new Menu();
            }
        }
        private List<AnaMenu> _anaMenuList;
        public List<AnaMenu> ananaMenuList
        {
            get
            {
                if (_anaMenuList == null)
                {
                    _anaMenuList = GetModelList(WebMethods.GetAnaMenu, anaMenu);
                }
                else if (_anaMenuList.Count == 0)
                {
                    _anaMenuList = GetModelList(WebMethods.GetAnaMenu, anaMenu);
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
                    _menuList = GetModelList(WebMethods.GetMenu, menu);
                }
                else if (_menuList.Count == 0)
                {
                    _menuList = GetModelList(WebMethods.GetMenu, menu);
                }
                return _menuList;
            }
        }
        private Yetki yetki
        {
            get { return new Yetki { rolId = kullanici.rolId }; }
        }
        private List<Yetki> _yetkiList;
        public List<Yetki> yetkiList
        {
            get
            {
                if (_yetkiList == null)
                {
                    _yetkiList = GetModelList(WebMethods.GetYetki, yetki);
                }
                return _yetkiList;
            }
        }

        private List<ParcaGrup> _parcaGrups;
        public List<ParcaGrup> parcaGrups
        {
            get
            {
                if (_parcaGrups == null)
                {
                    _parcaGrups = GetModelList(WebMethods.GetParcaGrup, new ParcaGrup());
                }
                return _parcaGrups;
            }
        }
        private List<StokTip> _stokTips;
        public List<StokTip> stokTips
        {
            get
            {
                if (_stokTips == null)
                {
                    _stokTips = GetModelList(WebMethods.GetStokTip, new StokTip());
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
                    _profilTips = GetModelList(WebMethods.GetProfilTip, new ProfilTip());
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
                    _olcuBirims = GetModelList(WebMethods.GetOlcuBirim, new OlcuBirim());
                }
                return _olcuBirims;
            }
        }
        private List<MalzemeGrup> _malzemeGrups;
        public List<MalzemeGrup> malzemeGrups
        {
            get
            {
                if (_malzemeGrups == null)
                {
                    _malzemeGrups = GetModelList(WebMethods.GetMalzemeGrup, new MalzemeGrup());
                }
                return _malzemeGrups;
            }
        }
        private List<MalzemeStandart> _malzemeStandarts;
        public List<MalzemeStandart> malzemeStandarts
        {
            get
            {
                if (_malzemeStandarts == null)
                {
                    _malzemeStandarts = GetModelList(WebMethods.GetMalzemeStandart, new MalzemeStandart());
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
                    _projes = GetModelList(WebMethods.GetProje, new Proje()).Where(x => x.personel.Id == kullanici.personel.Id).ToList();
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
                    _unAssignedProjeList = GetModelList(WebMethods.GetProje, new Proje()).Where(x => x.satisSiparisId == 0).ToList();
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
                    _sektorList = GetModelList(WebMethods.GetSektor, new Sektor());
                }
                return _sektorList;
            }
        }
        public List<T> GetModelList<T>(Func<T, string> fetchFunction, T t) where T : IEntity, new()
        {
            DataTable dataTable = JsonConverter.JsonStringToDataSet(fetchFunction.Invoke(t)).Tables[0];
            List<T> list = DataTableConverter.DataTableRowsToModelList<T>(dataTable.AsEnumerable().ToList());
            return list;
        }
        private List<Firma> _firmaList;
        public List<Firma> firmaList
        {
            get
            {
                if (_firmaList == null)
                {
                    _firmaList = GetModelList(WebMethods.GetFilteredFirma, new Firma());
                }
                return _firmaList;
            }
        }
    }
}
