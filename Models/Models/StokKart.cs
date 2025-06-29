using Models.Attributes;
using Models.Interface;
using System.Text.RegularExpressions;

namespace Models
{
    [Serializable]
    public class StokKart : IEntity
    {
        
        public int? Id { get; set; }
        public int? hammaddeId { get; set; }
        /// <summary>   
        /// bu alan sanal olarak seçim yapmak için oluşturuldu, veritabanında bir karşılığı yok.
        /// </summary>
        public bool? sec { get; set; }
        [FilterAttribute]
        public string parcaKod { get; set; }
        public string kod { get; set; }
        public string logoKod { get; set; }
        [FilterAttribute]
        public string ad { get; set; }
        [FilterAttribute]
        public string boyut { get; set; }
        public double? uzunluk { get; set; }
        public string aciklama { get; set; }
        public double? agirlik { get; set; }
        public double? miktar { get; set; }
        public string malzeme { get; set; }
        [FilterAttribute]
        public string parcaAdi { get; set; }
        public int adet { get; set; }
        public int fark { get; set; }
        private StokGrup _stokGrup;
        [FilterAttribute]
        public StokGrup stokGrup { get { if (_stokGrup == null) { _stokGrup = new StokGrup(); } return _stokGrup; } set { _stokGrup = value; } }
        private StokTip _stokTip;
        
        public StokTip stokTip 
        { 
            get 
            { 
                if (_stokTip == null) 
                {
                    _stokTip = new StokTip();
                    
                }
                else if(_stokGrup.Id == 1)
                {
                    _stokTip.Id = 2; //Eğer stok grubu metal ise stok tipi yarı mamül olarak ayarlanır.
                }
                return _stokTip; 
            } 
            set 
            { 
                _stokTip = value; 
            } 
        }
        public int profilTipId { get; set; }

        [FilterAttribute]
        public bool? isSatinalma;
        public bool? isFromExcel { get; set; }
        public double etKalinligi { get; set; }
        public double en { get; set; }
        public double boy { get; set; }
        public double cap { get; set; }
        public double yukseklik { get; set; }
        private OlcuBirim _olcuBirim;
        public OlcuBirim olcuBirim { get { if (_olcuBirim == null) { _olcuBirim = new OlcuBirim(); } return _olcuBirim; } set { _olcuBirim = value; } }
        
        private MalzemeGrup _malzemeGrup;
        [FilterAttribute]
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        private MalzemeAltGrup _malzemeAltGrup;
        [FilterAttribute]
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }
        private MalzemeAltGrup2 _malzemeAltGrup2;
        [FilterAttribute]
        public MalzemeAltGrup2 malzemeAltGrup2 { get { if (_malzemeAltGrup2 == null) { _malzemeAltGrup2 = new MalzemeAltGrup2(); } return _malzemeAltGrup2; } set { _malzemeAltGrup2 = value; } }
        private MalzemeStandart _malzemeStandart;
        public MalzemeStandart malzemeStandart { get { if (_malzemeStandart == null) { _malzemeStandart = new MalzemeStandart(); } return _malzemeStandart; } set { _malzemeStandart = value; } }

        private List<StokKartDosya> _stokKartDosya;
        public List<StokKartDosya> stokKartDosya
        {
            get
            {
                if (_stokKartDosya == null)
                {
                    _stokKartDosya = new List<StokKartDosya>();
                }
                return _stokKartDosya;
            }
            set
            {
                _stokKartDosya = value;
            }
        }
        [FilterAttribute]
        public bool? isPdf;
        [FilterAttribute]
        public bool? isDxf;
        [FilterAttribute]
        public bool? isStep;
        public byte[] pdf { get; set; }
        public byte[] step { get; set; }
        public byte[] dxf { get; set; }
        private Proje _proje;
        public Proje proje { get { if (_proje == null) _proje = new Proje(); return _proje; } set { _proje = value; } }
        public string pdfFileName() { return parcaKod + ".pdf"; }
        public string dxfFileName()
        {
            string dxfAd = $"{parcaKod}_{malzeme}_{dxfAddition()}mm_{adet}adet.dxf";
            return dxfAd;
        }
        public string stepFileName() { return parcaKod + ".step"; }
        public string dxfAddition()
        {
            string pattern = @"(\d+(?:\.\d+)?)"; // Sayısal kısmı yakalayan desen

            // Regex ile eşleşmeyi bul
            Match match = Regex.Match(boyut, pattern);
            if (match.Success)
            {
                string result = match.Groups[1].Value; // Tam sayı kısmını al
                return result;
            }
            return "";
        }
        string FormatKod(string kod,int spc)
        {
            return string.IsNullOrWhiteSpace(kod) ? "0".PadLeft(spc,'0') : kod.PadLeft(spc, '0');
        }

       
        public string hammaddeKod
        {
            get
            {
                return string.Join("_",
                FormatKod(stokGrup.kod, 2),
                FormatKod(malzemeGrup.kod, 3),
                FormatKod(malzemeAltGrup.kod, 4),
                string.Join("",FormatKod(malzemeAltGrup2.kod, 1),
                FormatKod(boyut, 2),
                FormatKod(malzeme,2)));
            }
        }
    }
    public class StokGrup : IEntity
    {
        [FilterAttribute]
        public int Id;
        public string kod;
        public string ad;
    }
    public class MalzemeGrup : IEntity
    {
        [FilterAttribute]
        public int Id;
        private StokGrup _stokGrup;
        public StokGrup stokGrup { get { if (_stokGrup == null) { _stokGrup = new StokGrup(); } return _stokGrup; } set { _stokGrup = value; } }
        public string kod;
        public string ad;
    }
    public class MalzemeAltGrup : IEntity
    {
        [FilterAttribute]
        public int? Id;
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        public string kod;
        public string ad;
    }
    public class MalzemeAltGrup2 : IEntity,IBaseEntity
    {
        [FilterAttribute]
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        private MalzemeAltGrup _malzemeAltGrup;
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }


        public bool isUretim;
    }
    public class StokTip : IEntity
    {
        [FilterAttribute]
        public int Id;
        public string kod;
        public string ad;
    }
    public class ProfilTip : IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class MalzemeStandart : IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class StokKartDosya : IEntity
    {
        public int Id;
        public int stokKartId;
        private DosyaTip _dosyaTip;
        public DosyaTip dosyaTip { get { if (_dosyaTip == null) { _dosyaTip = new DosyaTip(); } return _dosyaTip; } set { _dosyaTip = value; } }
        public string dosyaAd;
        public string dosyaUzanti;
        public byte[] dosya;
    }
}
