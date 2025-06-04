namespace Models
{
    public class SatinalmaTalep:IEntity
	{
		public int Id;
		public string satinalmaTalepNo;
		public DateTime talepTarihi;
		public long malzemeGrupId;
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
		public int talepEdenKullaniciId;
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
		public int Id;
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
		public int? miktar;
		public string aciklama;
		public DateTime talepTarihi;
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
		public int Id;
        public int satinalmaDetayId;
        public int? stokKartId;
        public int? miktar;
    }

}
