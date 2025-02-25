namespace Models
{
    public class Marka:IEntity
    {
        public int Id;
        public string ad;
        public string kod;
        public string prefix;
        private MarkaAltGrup _markaAltGrup;
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }
    }
    public class MarkaAltGrup:IEntity
    {
        public int Id;
        public string ad;
        public string kod;
        public int markaId;
    }
}
