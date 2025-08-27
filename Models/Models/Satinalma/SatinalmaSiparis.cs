namespace Models
{
    public record SatinalmaSiparis:IEntity
    {
        public int? Id { get; set; }
        public string siparisNo { get; set; }
        private Proje _proje;
        public Proje proje
        {
            get { if(_proje==null) _proje=new Proje(); return _proje; }
            set { _proje = value; }
        }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup
        {
            get { if (_malzemeGrup == null) _malzemeGrup = new MalzemeGrup(); return _malzemeGrup; }
            set { _malzemeGrup = value; }
        }
        public DateTime? siparisTarihi { get; set; }
        public DateTime? teslimTarihi { get; set; }
        public double? tutar { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
        public double? avans { get; set; }
        private DovizCinsi _avansDovizCinsi;
        public DovizCinsi avansDovizCinsi { get { if (_avansDovizCinsi == null) { _avansDovizCinsi = new(); } return _avansDovizCinsi; } set { _avansDovizCinsi = value; } }
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new(); } return _kdv; } set { _kdv = value; } }
        private Vade _vade;
        public Vade vade { get { if (_vade == null) _vade = new Vade(); return _vade; } set { _vade = value; } }
        private Firma _firma;
        public Firma firma
        {
            get { if (_firma == null) _firma = new Firma(); return _firma; }
            set { _firma = value; }
        }
        public string aciklama { get; set; }
        private SatinalmaTeklifBaslik _satinalmaTeklif;
        public SatinalmaTeklifBaslik satinalmaTeklif { get { if (_satinalmaTeklif == null) { _satinalmaTeklif = new(); } return _satinalmaTeklif; } set { _satinalmaTeklif = value; } }
        private List<SatinalmaSiparisDetay> _satinalmaSiparisDetayList;
        public List<SatinalmaSiparisDetay> satinalmaSiparisDetayList { get { if (_satinalmaSiparisDetayList == null) { _satinalmaSiparisDetayList = new(); } return _satinalmaSiparisDetayList; } set { _satinalmaSiparisDetayList = value; } }
    }
    public record SatinalmaSiparisDetay : IEntity
    {
        public int? Id { get; set; }
        public int? satinalmaSiparisBaslikId { get; set; }
        public int? stokKartId { get; set; }
        public double? miktar { get; set; }
        public double? birimFiyat { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi=value; } }
        public string aciklama { get; set; }    
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new(); } return _kdv; } set { _kdv = value; } }
    }
}
