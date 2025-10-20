using Models.Attributes;
using Models.Interface;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Models
{
    public record StokKart : IEntity
    {
        [GridDisplay(Header = "Stok Kart Id", Visible = false)] public int? Id { get; set; }
        private Hammadde _hammadde;
        public Hammadde hammadde { get { if (_hammadde == null) { _hammadde = new(); } return _hammadde; } set { _hammadde = value; } }
        public string parcaKod { get; set; }
        [GridDisplay(Header = "Stok Kodu", Visible = false)] public string kod { get; set; }
        public string logoKod { get; set; }
        public string tedarikciKod { get; set; }
        [GridDisplay(Header = "Stok Adı")] public string ad { get; set; }
        [GridDisplay(Header = "Boyut")] public string boyut { get; set; }
        [GridDisplay(Header = "Uzunluk")] public double? uzunluk { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "Ağırlık")] public double? agirlik { get; set; }
        public string malzeme { get; set; }
        public string parcaAdi { get; set; }
        public int fark { get; set; }
        private StokGrup _stokGrup;
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
                return _stokTip; 
            } 
            set 
            { 
                _stokTip = value; 
            } 
        }
        public int profilTipId { get; set; }
        [GridDisplay(Header = "isSatinalma", Visible = false)] public bool? isSatinalma { get; set; }
        public bool? isFromExcel { get; set; }
        [GridDisplay(Header = "Et Kalınlığı")] public double? etKalinligi { get; set; }
        [GridDisplay(Header = "En")] public double? en { get; set; }
        [GridDisplay(Header = "Boy")] public double? boy { get; set; }
        [GridDisplay(Header = "Çap")] public double? cap { get; set; }
        [GridDisplay(Header = "Yükseklik")] public double? yukseklik { get; set; }
        private OlcuBirim _olcuBirim;
        public OlcuBirim olcuBirim { get { if (_olcuBirim == null) { _olcuBirim = new OlcuBirim(); } return _olcuBirim; } set { _olcuBirim = value; } }
        
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        private MalzemeAltGrup _malzemeAltGrup;
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }
        private MalzemeAltGrup2 _malzemeAltGrup2;
        public MalzemeAltGrup2 malzemeAltGrup2 { get { if (_malzemeAltGrup2 == null) { _malzemeAltGrup2 = new MalzemeAltGrup2(); } return _malzemeAltGrup2; } set { _malzemeAltGrup2 = value; } }
        private Boyut _boyutTanim;
        public Boyut boyutTanim
        {
            get { if (_boyutTanim == null) { _boyutTanim = new(); } return _boyutTanim; }
            set { _boyutTanim = value; }
        }
        private MalzemeStandart _malzemeStandart;
        public MalzemeStandart malzemeStandart { get { if (_malzemeStandart == null) { _malzemeStandart = new MalzemeStandart(); } return _malzemeStandart; } set { _malzemeStandart = value; } }
        public bool? isTalasli { get; set; }
        public bool? isBukum { get; set; }
        private List<StokKartDosya> _dosyaList;
        [GridDisplay(Header = "Stok Kart Dosyaları", Visible = false)]
        public List<StokKartDosya> dosyaList
        {
            get
            {
                if (_dosyaList == null)
                {
                    _dosyaList = new List<StokKartDosya>();
                }
                return _dosyaList;
            }
            set
            {
                _dosyaList = value;
            }
        }
        [GridDisplay(Header = "isPdf", Visible = false)] public bool? isPdf { get; set; }
        [GridDisplay(Header = "isDxf", Visible = false)] public bool? isDxf { get; set; }
        public bool? isStep { get; set; }
        public byte[] pdf { get; set; }
        public byte[] step { get; set; }
        public byte[] dxf { get; set; }
        
    }
    public class  Hammadde: IEntity
    {
        [GridDisplay(Header = "Stok Kart Id", Visible = false)] public int? Id { get; set; }
        public string parcaKod { get; set; }
        public string kod { get; set; }
        public string logoKod { get; set; }
        public string tedarikciKod { get; set; }
        public string ad { get; set; }
        public string boyut { get; set; }
        public double? uzunluk { get; set; }
        public string aciklama { get; set; }
        public double? agirlik { get; set; }
        public string malzeme { get; set; }
        public string parcaAdi { get; set; }
        public int fark { get; set; }
        private StokGrup _stokGrup;
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
                else if (stokGrup.Id == 1)
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
        public bool? isSatinalma { get; set; }
        public bool? isFromExcel { get; set; }
        public double? etKalinligi { get; set; }
        public double? en { get; set; }
        public double? boy { get; set; }
        public double? cap { get; set; }
        public double? yukseklik { get; set; }
        private OlcuBirim _olcuBirim;
        public OlcuBirim olcuBirim { get { if (_olcuBirim == null) { _olcuBirim = new OlcuBirim(); } return _olcuBirim; } set { _olcuBirim = value; } }

        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        private MalzemeAltGrup _malzemeAltGrup;
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }
        private MalzemeAltGrup2 _malzemeAltGrup2;
        public MalzemeAltGrup2 malzemeAltGrup2 { get { if (_malzemeAltGrup2 == null) { _malzemeAltGrup2 = new MalzemeAltGrup2(); } return _malzemeAltGrup2; } set { _malzemeAltGrup2 = value; } }
        private MalzemeStandart _malzemeStandart;
        public MalzemeStandart malzemeStandart { get { if (_malzemeStandart == null) { _malzemeStandart = new MalzemeStandart(); } return _malzemeStandart; } set { _malzemeStandart = value; } }

        private List<StokKartDosya> _dosyaList;
        public List<StokKartDosya> dosyaList
        {
            get
            {
                if (_dosyaList == null)
                {
                    _dosyaList = new List<StokKartDosya>();
                }
                return _dosyaList;
            }
            set
            {
                _dosyaList = value;
            }
        }
        public bool? isPdf { get; set; }
        public bool? isDxf { get; set; }
        public bool? isStep { get; set; }
        public byte[] pdf { get; set; }
        public byte[] step { get; set; }
        public byte[] dxf { get; set; }
    }
}
