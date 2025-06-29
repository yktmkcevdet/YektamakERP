using Models.Attributes;

namespace Models
{
    public class Kullanici:IEntity
    {
        [GridDisplay(Header = "Id", Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "kod", Visible = true)]
        public string kod { get; set; }
        [GridDisplay(Header = "ad", Visible = true)]
        public string ad { get; set; }
        public string sifre { get; set; }
        public string salt { get; set; }
        private Personel _personel;
        public Personel personel { get { if (_personel == null) _personel = new Personel(); return _personel; } set { _personel = value; } }
        private Rol _rol;
        public Rol rol { get { if (_rol == null) _rol = new Rol(); return _rol; } set { _rol = value; } }
        public bool? isSifreDegisti { get; set; }
    }
    //public enum Rol
    //{
    //    admin=1,
    //    satış=2,
    //    satınalma=3,
    //    muhasebe=4,
    //    ProjeTasarımMühendisi=5,
    //    ProjeYöneticisi=6,
    //    ProjeMüdürü=7
    //}
}
