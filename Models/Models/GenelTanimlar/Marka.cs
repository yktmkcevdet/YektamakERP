namespace Models
{
    public class Marka : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        public string prefix { get; set; }
    }
    public class MarkaAltGrup : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        private Marka _marka;
        public Marka marka
        {
            get { if (_marka == null) { _marka = new(); } return _marka; }
            set { _marka= value; }
        }
    }
    public class MarkaAltGrupKategori : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        private MarkaAltGrup _markaAltGrup;
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }
    }
}
