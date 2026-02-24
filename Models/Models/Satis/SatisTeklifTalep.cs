namespace Models
{
    public class SatisTeklifTalep:IEntity
    {
        public int? Id { get; set; }
        public DateTime? teklifTalepTarihi;
        private Personel _satisSorumlusu;
        public Personel satisSorumlusu { get { if (_satisSorumlusu == null) { _satisSorumlusu = new(); } return _satisSorumlusu; } set { _satisSorumlusu = value; } }
        private Firma _musteri;
        public Firma musteri{ get { if (_musteri == null) { _musteri = new(); } return _musteri; } set { _musteri = value; } }
        public string teklifKonusu;
        private Marka _marka;
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }
        private MarkaAltGrup _altGrup;
        public MarkaAltGrup altGrup { get { if (_altGrup == null) { _altGrup = new(); } return _altGrup; } set { _altGrup = value; } }
        public int? referansKaynakId { get; set; }
        private Personel _maliyetSorumlusu;
        public Personel maliyetSorumlusu { get { if (_maliyetSorumlusu == null) { _maliyetSorumlusu = new(); } return _maliyetSorumlusu; } set { _maliyetSorumlusu = value; } }
        public bool isMaliyetOk;
        public bool isOnay;
        private List<SatisSiparisTeklifTalepBelge> _belgeList;
        public List<SatisSiparisTeklifTalepBelge> belgeList { get { if (_belgeList == null) { _belgeList = new(); } return _belgeList; } set { _belgeList = value; } }
        private List<SatisTeklifMaliyet> _satisTeklifMaliyetList;
        public List<SatisTeklifMaliyet> satisTeklifMaliyetList { get { if (_satisTeklifMaliyetList == null) { _satisTeklifMaliyetList = new(); } return _satisTeklifMaliyetList; } set { _satisTeklifMaliyetList = value; } }
        public bool isMaliyetTalep { get; set; }
    }
    public class  SatisSiparisTeklifTalepBelge:IEntity
    {
        public int? Id { get; set; }
        public int teklifTalepId { get; set; }
        public string belgeAd { get; set; }
        public string dosyaAd { get; set; }
        public string dosyaUzanti { get; set; }
        public string belgeAciklama { get; set; }
        public byte[] dosyaVeri { get; set; }
        public double dosyaBoyut { get; set; }
    }
    public class SatisTeklifMaliyet : IEntity
    {
        public int? Id { get; set; }
        public int teklifTalepId { get; set; }
        public int? maliyetUnsurId { get; set; }
        public int? maliyetTespitKanali { get; set; }
        public double maliyetTutar { get; set; }
        public int dovizCinsiId { get; set; }
        public byte[] belge { get; set; }
    }
}
