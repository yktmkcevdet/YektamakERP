namespace Models
{
    public class Tutar:IEntity
    {
        public double? tutar { get; set; }
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) _dovizCinsi = new DovizCinsi(); return _dovizCinsi; } set { _dovizCinsi = value; } }
    }

    public class DovizCinsi:IEntity
    {
        public int? Id { get; set; }
        public string kod{get;set;}
        public string ad{ get; set; }
    }
}
