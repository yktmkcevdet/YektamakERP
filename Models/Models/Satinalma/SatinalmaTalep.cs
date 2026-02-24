using Models.DTO;

namespace Models
{
    public class SatinalmaTalep:IEntity
	{
		public int? Id { get; set; }
        public string satinalmaTalepNo { get; set; }
		public int? setAdet { get; set; }
        public DateTime? talepTarihi { get; set; }
        public DateTime? teslimTarihi { get; set; }
        public bool? onayDurum { get; set; }
		private TalepNeden _talepNeden;
		public TalepNeden talepNeden
        {
            get { if (_talepNeden == null) _talepNeden = new(); return _talepNeden; }
            set { _talepNeden = value; }
        }
        private StokTip _stokTip;
		public StokTip stokTip
		{
            get { if (_stokTip == null) _stokTip = new(); return _stokTip; }
            set { _stokTip = value; }
        }
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
		public string aciklama { get; set; }
        private List<SatinalmaTalepDetay> _satinalmaTalepDetays;
		public List<SatinalmaTalepDetay> satinalmaTalepDetays
		{
			get { if (_satinalmaTalepDetays == null) _satinalmaTalepDetays = new List<SatinalmaTalepDetay>(); return _satinalmaTalepDetays; }
			set { _satinalmaTalepDetays = value; }
		}
	}
	public class SatinalmaTalepDetay : IEntity
	{
		public int? Id { get; set; }
		public string satinalmaTalepNo { get; set; }
		private Proje _proje;
		public Proje proje { get { if (_proje == null) _proje = new Proje(); return _proje; } set { _proje = value; } }

        private TalepNeden _talepNeden;
        public TalepNeden talepNeden { get { if (_talepNeden == null) _talepNeden = new(); return _talepNeden; } set { _talepNeden = value; } }
        private ProjeStokKart _projeStokKart;
		public ProjeStokKart projeStokKart{
			get
			{
				if (_projeStokKart == null)
				{
					_projeStokKart = new ProjeStokKart();
				}
				return _projeStokKart;
			}
			set
			{
				_projeStokKart = value;
			}
		}
		public double? miktar { get; set; }
        public double? onaylananMiktar { get; set; }
        public double? agirlik { get; set; }
        public string aciklama { get; set; }
        public DateTime? talepTarihi { get; set; }
        public DateTime? teslimTarihi { get; set; }
        public string onayPersonelad { get; set; }
		public string talepEdenPersonelad { get; set; }
		public bool? onayDurum { get; set; }
		public bool? isTeklif { get; set; }
        public bool? isSiparis { get; set; }
        public int? teklifSayisi { get; set; }
        private List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        public List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays
        {
            get { if (_satinalmaTalepSatirDetays == null) _satinalmaTalepSatirDetays = new List<SatinalmaTalepSatirDetay>(); return _satinalmaTalepSatirDetays; }
            set { _satinalmaTalepSatirDetays = value; }
        }
    }
	public class TalepTip:IEntity
	{
		public int Id { get; set; }
		public string talepTipi { get; set; }
        public string kod { get; set; }
    }
	public class SatinalmaTalepSatirDetay : IEntity
	{
		public int? Id { get; set; }
		private ProjeStokKart _projeStokKart;
		public ProjeStokKart projeStokKart
		{
			get
			{
				if (_projeStokKart == null)
				{
					_projeStokKart = new ProjeStokKart();
				}
				return _projeStokKart;
			}
			set
			{
				_projeStokKart = value;
			}
		}
		public double? miktar { get; set; }
		public string stokKartKod { get; set; }
		public string stokKartAd { get; set; }
	}

}
