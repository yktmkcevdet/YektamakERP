using Models.Attributes;

namespace Models
{
    [Serializable]
    public class Personel:IEntity
    {
        [GridDisplay(Header = "ID", Visible = true, IsRequired = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Ad", Visible = true)]
        public string ad { get; set; }
        public string kod { get; set; }
        [GridDisplay(Header = "Soyad", Visible = true)]
        public string soyad { get; set; }
        [GridDisplay(Header = "Telefon", Visible = true)]
        public string telefon { get; set; }//Daha sonra property içinde formatlama kuralları yazılacak +xx(xxx)xxxxxxx gibi
        public string mail { get; set; }//Daha sonra property içinde formatlama kuralları yazılacak ****@***.com** gibi
        public string pozisyon { get; set; }
        private Firma _firma;
        public Firma firma { get { if(_firma == null){ _firma = new(); } return _firma; } set { _firma = value; } }
        private PersonelResim _personelResim;
        public PersonelResim personelResim { get { if (_personelResim == null) { _personelResim = new(); } return _personelResim; } set { _personelResim = value; } }

       
        
    }

    [Serializable]
    public class PersonelResim:IEntity
    {
        public int id;
        public int personelId;
        public byte[] resimData;
        public string imageFormat;
    }

    [Serializable]
    public class CariPersonel
    {
        public Personel personel;
    }
}
