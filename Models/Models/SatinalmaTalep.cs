namespace Models
{
    public class SatinalmaTalep:IEntity
	{
		public int Id;
		public string satinalmaTalepNo;
		public DateTime talepTarihi;
        public DateTime teslimTarihi;
		public bool? onayDurum { get; set; }
		private MalzemeGrup _malzemeGrup;
		public MalzemeGrup malzemeGrup
        {
            get { if (_malzemeGrup == null) _malzemeGrup = new MalzemeGrup(); return _malzemeGrup; }
            set { _malzemeGrup = value; }
        }
        private Proje _proje;
		public Proje proje
		{
			get
			{
				if(_proje == null) 
				{ 
					_proje = new Proje();
				}
				return _proje;
			}
			set
			{
				_proje = value;
			}
		}
		private Kullanici _talepEdenKullanici;
        public Kullanici talepEdenKullanici { 
			get { if (_talepEdenKullanici == null) _talepEdenKullanici = new Kullanici(); return _talepEdenKullanici; } 
			set { _talepEdenKullanici = value; } }
		private Kullanici _onayKullanici;
		public Kullanici onayKullanici { 
			get { if (_onayKullanici == null) _onayKullanici = new Kullanici(); return _onayKullanici; } 
			set { _onayKullanici = value; } 
		}
        public TalepTip _talepTip;
		public TalepTip talepTip
		{
			get
			{
				if (_talepTip == null)
				{
					_talepTip=new TalepTip();
				}
				return _talepTip;
			}
			set
			{
				_talepTip = value;
			}
		}
		public string aciklama;
		private List<SatinalmaTalepDetay> _satinalmaTalepDetays;
		public List<SatinalmaTalepDetay> satinalmaTalepDetays
		{
			get { if (_satinalmaTalepDetays == null) _satinalmaTalepDetays = new List<SatinalmaTalepDetay>(); return _satinalmaTalepDetays; }
			set { _satinalmaTalepDetays = value; }
		}
	}
	public class SatinalmaTalepDetay : IEntity
	{
		public int? Id;
		private StokKart _stokKart;
		public StokKart stokKart{
			get
			{
				if (_stokKart == null)
				{
					_stokKart = new StokKart();
				}
				return _stokKart;
			}
			set
			{
				_stokKart = value;
			}
		}
		public double? miktar;
		public double agirlik;
		public string aciklama;
		public DateTime? talepTarihi;
		private List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        public List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays
        {
            get { if (_satinalmaTalepSatirDetays == null) _satinalmaTalepSatirDetays = new List<SatinalmaTalepSatirDetay>(); return _satinalmaTalepSatirDetays; }
            set { _satinalmaTalepSatirDetays = value; }
        }
    }
	public class TalepTip:IEntity
	{
		public int talepTipId;
		public string talepTipi;
		public string kod;
	}
	public class SatinalmaTalepSatirDetay:IEntity
	{
		public int? Id;
		private StokKart _stokKart;
		public StokKart stokKart
		{
			get
			{
				if (_stokKart == null)
				{
					_stokKart = new StokKart();
				}
				return _stokKart;
			}
			set
			{
				_stokKart = value;
			}
        }
        public double? miktar;
		public string stokKartKod;
        public string stokKartAd;
    }

}
