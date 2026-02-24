namespace Models
{
    public class SatisFatura:IEntity
    {
        public int satisFaturaId;
        public string faturaNo;
        private SatisSiparis _satisSiparis;
        public SatisSiparis satisSiparis { get { if (_satisSiparis == null) { _satisSiparis = new(); } return _satisSiparis; } set { _satisSiparis = value; } }
    
        public DateTime faturaTarihi;
        public double? tutar { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
        private CariKart _cariKart;
        public CariKart cariKart { get { if (_cariKart == null) { _cariKart = new(); } return _cariKart; } set { _cariKart = value; } }
        public float faturalandirilmamisTutar;
    }
}
