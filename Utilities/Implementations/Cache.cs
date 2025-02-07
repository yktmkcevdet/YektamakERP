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
        private readonly IDataTableConverter DataTableConverter;
        public Cache(IJsonConvertHelper jsonConverter, IDataTableConverter dataTableConverter)
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
        private List<StokTip> _stokTip;
        public List<StokTip> stokTip
        {
            get
            {
                if (_stokTip == null)
                {
                    _stokTip = GetModelList(WebMethods.GetStokTip, new StokTip());
                }
                return _stokTip;
            }
        }
        private List<ProfilTip> _profilTip;
        public List<ProfilTip> profilTip
        {
            get
            {
                if (_profilTip == null)
                {
                    _profilTip = GetModelList(WebMethods.GetProfilTip, new ProfilTip());
                }
                return _profilTip;
            }
        }
        private List<OlcuBirim> _olcuBirim;
        public List<OlcuBirim> olcuBirim
        {
            get
            {
                if (_olcuBirim == null)
                {
                    _olcuBirim = GetModelList(WebMethods.GetOlcuBirim, new OlcuBirim());
                }
                return _olcuBirim;
            }
        }
        private List<MalzemeGrup> _malzemeGrup;
        public List<MalzemeGrup> malzemeGrup
        {
            get
            {
                if (_malzemeGrup == null)
                {
                    _malzemeGrup = GetModelList(WebMethods.GetMalzemeGrup, new MalzemeGrup());
                }
                return _malzemeGrup;
            }
        }
        private List<MalzemeStandart> _malzemeStandart;
        public List<MalzemeStandart> malzemeStandart
        {
            get
            {
                if (_malzemeStandart == null)
                {
                    _malzemeStandart = GetModelList(WebMethods.GetMalzemeStandart, new MalzemeStandart());
                }
                return _malzemeStandart;
            }
        }
        private List<Proje> _proje;
        public List<Proje> proje
        {
            get
            {
                if (_proje == null)
                {
                    _proje = GetModelList(WebMethods.GetProje, new Proje()).Where(x => x.personel.Id == kullanici.personel.Id).ToList();
                }
                return _proje;
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
            List<T> list = DataTableConverter.ToList<T>(dataTable.AsEnumerable().ToList());
            return list;
        }
    }
}
