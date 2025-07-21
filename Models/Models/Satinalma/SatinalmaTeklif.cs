namespace Models
{
    public class SatinalmaTeklifBaslik:IEntity
    {
        public int? Id { get; set; }
        public string teklifNo { get; set; }
        public DateTime teklifTalepTarihi { get; set; }
        private Firma _teklifFirma;
        public Firma teklifFirma
        {
            get
            {
                if (_teklifFirma == null)
                {
                    _teklifFirma= new Firma();
                }
                return _teklifFirma;  
            }
            set
            {
                _teklifFirma = value;
            }
        }
        public DateTime? teklifTarihi { get; set; }
        private Tutar _teklifTutar;
        public Tutar teklifTutar
        {
            get
            {
                if(_teklifTutar == null)
                {
                    _teklifTutar=new Tutar();
                }
                return _teklifTutar;
            }
            set
            {
                _teklifTutar = value;
            }
        }
        public int teklifGecerlilikSuresi { get; set; }
        public int? terminSuresi { get; set; }
        private Vade _vade;
        public Vade vade
        {
            get
            {
                if(_vade == null)
                {
                    _vade=new Vade();
                }
                return _vade;
            }
            set { _vade = value; }
        }
        public string aciklama { get; set; }
        private List<SatinalmaTeklifDetay> _satinalmaTeklifDetayList;
        public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList
        {
            get
            {
                if(_satinalmaTeklifDetayList==null) _satinalmaTeklifDetayList=new List<SatinalmaTeklifDetay> ();
                return _satinalmaTeklifDetayList;
            }
            set
            {
                _satinalmaTeklifDetayList = value;
            }
        }
    }
    public class SatinalmaTeklifDetay:IEntity
    {
        public int? Id { get; set; }
        private SatinalmaTalepDetay _satinalmaTalepDetay;
        public SatinalmaTalepDetay satinalmaTalepDetay 
        {
            get { if (_satinalmaTalepDetay == null) { _satinalmaTalepDetay = new(); } return _satinalmaTalepDetay; } set { _satinalmaTalepDetay = value; } } 
        private Tutar _birimFiyat;
        public Tutar birimFiyat
        {
            get
            {
                if (_birimFiyat == null) { _birimFiyat = new(); } return _birimFiyat;
            }
            set
            {
                _birimFiyat = value;
            }
        }
    }
}
