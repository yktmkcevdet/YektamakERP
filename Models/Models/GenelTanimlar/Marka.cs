namespace Models
{
    public class Marka : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        public string prefix { get; set; }
        private MarkaAltGrup _markaAltGrup;
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }
    }
    public class MarkaAltGrup : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        public int? markaId { get; set; }
    }
    public class MarkaAltGrupKategori : IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        public int? markaAltGrupId { get; set; }
    }
}
