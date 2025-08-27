

namespace Models
{
    public class Kasa : IEntity
    {
        public int kasaId;
        public DateTime sonGuncellemeTarihi;

        public string kasaAdi;
        public double? bakiye { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
        private KasaTip _kasaTip;
        public KasaTip kasaTip { get { if (_kasaTip == null) { _kasaTip = new(); } return _kasaTip; } set { _kasaTip = value; } }
        private BankaHesabi _bankaHesabi;
        public BankaHesabi bankaHesabi { get { if (_bankaHesabi == null) { _bankaHesabi = new(); } return _bankaHesabi; } set { _bankaHesabi = value; } }
    }
    public record KasaTip: IEntity
    {
        public int? Id { get; set; }
        public string kod{ get; set; }
        public string ad{ get; set; }
    }

}
