namespace Models
{
    public class CariKart:IEntity
    {
        public int cariKartId;
        public string cariAdi;
        private Cari _cari;
        public Cari cari { get { if (_cari == null) { _cari = new(); } return _cari; } set { _cari = value; } }
        public double? guncelCari { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
    }
    public enum CariTuru
    {
       FIRMA= 1,
       PERSONEL=2
    }

    [Serializable]
    public class Cari:IEntity
    {
        public CariTuru cariTuru { get; set; }
        /// <summary>
        /// Cari türü Personelse PersonelId, Firmaysa FirmaId
        /// </summary>
        public int Id;
        public int foreignId;
    }
    
}
