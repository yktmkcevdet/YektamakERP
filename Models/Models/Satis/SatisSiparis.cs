namespace Models
{
    [Serializable]
    public class SatisSiparis:IEntity
    {
        /// <summary>
        /// SatisSiparis tablosu indeksi
        /// </summary>
        public int Id;
        public string siparisNo;
        private SatisProje _satisProje;
        public SatisProje satisProje { get { if (_satisProje == null) { _satisProje = new(); } return _satisProje; } set { _satisProje= value; } }
       
        public DateTime siparisTarihi;
        public DateTime siparisTarihiFirst;
        /// <summary>
        /// Gün sayısı olarak siparişten itibaren teslim süresi
        /// </summary>
        public int teslimVadesi;
        public double? satisTutari { get; set; }
        private DovizCinsi _tutarDovizCinsi;
        public DovizCinsi tutarDovizCinsi { get { if (_tutarDovizCinsi == null) { _tutarDovizCinsi = new(); } return _tutarDovizCinsi; } set { _tutarDovizCinsi = value; } }
        public double? ongoruMaliyeti;
        private DovizCinsi _maliyetDovizCinsi;
        public DovizCinsi maliyetDovizCinsi { get { if (_maliyetDovizCinsi == null) { _maliyetDovizCinsi = new(); } return _maliyetDovizCinsi; } set { _maliyetDovizCinsi = value; } }
        /// <summary>
        /// 0,1,8,18 değerleri alabilir
        /// </summary>
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new(); } return _kdv; } set { _kdv = value; } }
        private TahsilatPlani _tahsilatPlani;
        public TahsilatPlani tahsilatPlani { get { if (_tahsilatPlani == null) { _tahsilatPlani = new(); } return _tahsilatPlani; } set { _tahsilatPlani = value; } }
        /// <summary>
        /// TahsilatPlani tablosu indeksi
        /// </summary>
        public int tahsilatPlaniId;
    }
}
