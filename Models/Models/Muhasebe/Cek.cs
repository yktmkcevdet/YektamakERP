namespace Models
{
    public class Cek:IEntity
    {
        /// <summary>
        /// Veri tabanındaki primaryKey
        /// </summary>
        public int cekId;
        /// <summary>
        /// Çek üzerindeki seri numarası
        /// </summary>
        public string cekNumarasi;
        public CekDurumu cekDurumu;
        public double? tutar { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
        public DateTime vadeTarihi;
        public DateTime vadeTarihiFirst;
        private Firma _cekiVerenFirma;
        public Firma cekiVerenFirma { get { if (_cekiVerenFirma == null) { _cekiVerenFirma = new(); } return _cekiVerenFirma; } set { _cekiVerenFirma = value; } }
        private Firma _cekiAlanFirma;
        public Firma cekiAlanFirma { get { if (_cekiAlanFirma == null) { _cekiAlanFirma = new(); } return _cekiAlanFirma; } set { _cekiAlanFirma = value; } }
        private Firma _cekSahibiBanka;
        public Firma cekSahibiBanka { get { if (_cekSahibiBanka == null) { _cekSahibiBanka = new(); } return _cekSahibiBanka; } set { _cekSahibiBanka = value; } }
        public DateTime cekinVerildigiTarih;
        public DateTime cekinVerildigiTarihFirst;
        private CekResim _cekResim;
        public CekResim cekResim { get { if (_cekResim == null) { _cekResim = new(); } return _cekResim; } set { _cekResim = value; } }
    }
    public class CekResim:IEntity
    {
        public int id;
        public int cekId;
        public byte[] onYuzResimData;
        public string onYuzImageFormat;
        public byte[] arkaYuzResimData;
        public string arkaYuzImageFormat;
    }

    public class CekDurumu:IEntity
    {
        public int cekDurumId;
        public string cekDurumAdi;
    }
}
