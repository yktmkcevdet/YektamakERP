using Models.Attributes;

namespace Models
{
    [Serializable]
    public class Firma:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
        [GridDisplay(Header = "kod")] public string kod { get; set; }
        private Adres _adres;
        public Adres adres { get { if (_adres == null) { _adres = new(); } return _adres; } set { _adres = value; } }
        [GridDisplay(Header = "vergiDairesi")] public string vergiDairesi { get; set; }
        [GridDisplay(Header = "vergiNumarasi")] public string vergiNumarasi { get; set; }
        private List<Sektor> _sektorIdList;
        public List<Sektor> sektorIdList { get { if (_sektorIdList == null) { _sektorIdList = new(); } return _sektorIdList; } set { _sektorIdList = value; } }
        private List<BankaHesabi> _bankaHesabiList;
        public List<BankaHesabi> bankaHesabiList { get { if (_bankaHesabiList == null) { _bankaHesabiList = new(); } return _bankaHesabiList; } set { _bankaHesabiList = value; } }
        private List<Personel> _yetkiliList;
        public List<Personel> yetkiliList { get { if (_yetkiliList == null) { _yetkiliList = new(); } return _yetkiliList; } set { _yetkiliList = value; } }
        [GridDisplay(Header = "telefon")] public string telefon { get; set; }
        [GridDisplay(Header = "faks")] public string faks { get; set; }
        [GridDisplay(Header = "mail")] public string mail { get; set; }
        [GridDisplay(Header = "LOGO ID")] public int? logoFirmaId { get; set; }

    }

    [Serializable]
    public class Adres:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "ulke")] public string ulke { get; set; }
        [GridDisplay(Header = "sehir")] public string sehir { get; set; }
        [GridDisplay(Header = "postaKodu")] public string postaKodu { get; set; }
        [GridDisplay(Header = "acikAdres")] public string acikAdres { get; set; }
        [GridDisplay(Header = "ilce")] public string ilce { get; set; }
        [GridDisplay(Header = "mahalle")] public string mahalle { get; set; }
        [GridDisplay(Header = "sokak")] public string sokak { get; set; }
    }

}
