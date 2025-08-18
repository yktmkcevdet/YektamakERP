using Models.Attributes;

namespace Models
{
    public record Kullanici:IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        public string sifre { get; set; }
        public string salt { get; set; }
        private Personel _personel;
        public Personel personel { get { if (_personel == null) _personel = new Personel(); return _personel; } set { _personel = value; } }
        private Rol _rol;
        public Rol rol { get { if (_rol == null) _rol = new Rol(); return _rol; } set { _rol = value; } }
        public bool? isSifreDegisti { get; set; }
    }
}
