using Models.Attributes;

namespace Models
{
    public record ProjeSorumlu:IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        private Proje _proje;
        [GridDisplay(Header ="Proje")]
        public Proje proje
        {
            get { if (_proje == null) { _proje = new(); } return _proje; }
            set { _proje = value; }
        }
        private Personel _personel;
        [GridDisplay(Header ="Personel")]
        public Personel personel
        {
            get { if (_personel == null) { _personel = new(); } return _personel; }
            set { _personel = value; }
        }
    }
}
