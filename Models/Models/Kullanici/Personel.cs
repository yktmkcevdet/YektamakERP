using Models.Attributes;

namespace Models
{
    public class Personel:IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public virtual string adSoyad { get; set; }
        public string kod { get; set; }
        public string telefon { get; set; }//Daha sonra property içinde formatlama kuralları yazılacak +xx(xxx)xxxxxxx gibi
        public string mail { get; set; }//Daha sonra property içinde formatlama kuralları yazılacak ****@***.com** gibi
        private Pozisyon _pozisyon;
        public Pozisyon pozisyon { 
            get { if (_pozisyon == null) { _pozisyon = new(); } return _pozisyon; } 
            set { _pozisyon = value; }
        }
        private Firma _firma;
        public Firma firma { get { if(_firma == null){ _firma = new(); } return _firma; } set { _firma = value; } }
        private PersonelResim _personelResim;
        public PersonelResim personelResim { get { if (_personelResim == null) { _personelResim = new(); } return _personelResim; } set { _personelResim = value; } }
        public int? yoneticiPersonelId { get; set; }
        //private Personel _yonetici;
        //public Personel yonetici { get { if (_yonetici == null) { _yonetici = new(); } return _yonetici; } set { _yonetici = value; } }

    }
    public class PersonelResim:IEntity
    {
        public int id;
        public int personelId;
        public byte[] resimData;
        public string imageFormat;
    }
    public class Pozisyon: IEntity
    {
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
    }
}
