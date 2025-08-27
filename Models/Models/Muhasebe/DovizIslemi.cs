namespace Models
{
    /// <summary>
    /// Bir döviz hesabındaki dövizi bankaya satıp , bir TL hesabına karşılığı olan parayı yatırma işlemi veya tam tersi için kullanılır.
    /// </summary>
    public class DovizIslemi:IEntity
    {
        public int? dovizIslemId;
        public DateTime islemTarihi;
        public double? satilanTutar { get; set; }
        private DovizCinsi _satilanTutarDovizCinsi;
        public DovizCinsi satilanTutarDovizCinsi { get { if (_satilanTutarDovizCinsi == null) { _satilanTutarDovizCinsi = new(); } return _satilanTutarDovizCinsi; } set { _satilanTutarDovizCinsi = value; } }
        public double? alinanTutar{ get; set; }
        private DovizCinsi _alinanTutarDovizCinsi;
        public DovizCinsi alinanTutarDovizCinsi { get { if (_alinanTutarDovizCinsi == null) { _alinanTutarDovizCinsi = new(); } return _alinanTutarDovizCinsi; } set { _alinanTutarDovizCinsi = value; } }
        private Kasa _cekilenKasa;
        public Kasa cekilenKasa { get { if (_cekilenKasa == null) _cekilenKasa = new Kasa(); return _cekilenKasa; } set { _cekilenKasa = value; } }
        private Kasa _yatirilanKasa;
        public Kasa yatirilanKasa { get { if (_yatirilanKasa == null) _yatirilanKasa = new Kasa(); return _yatirilanKasa; } set { _yatirilanKasa = value; } }
    }
}
