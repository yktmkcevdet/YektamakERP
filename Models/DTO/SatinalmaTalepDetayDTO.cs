using Models.Attributes;
using System.ComponentModel;
using static Models.DTO.SatinalmaTalepDetayDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTalepDetayDTO : IEntity,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        [GridDisplay(Header = IdHeader)] public int? Id { get; set; }
        [GridDisplay(Header = TalepNoHeader)]public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = TalepNedenIdHeader,Tip = "Liste", ListName = "talepNedenList", ListVisibleColumnName = "ad")] public int? talepNedenId { get; set; }
        [GridDisplay(Header = TalepNedenHeader)] public int? talepNedenad { get; set; }
        [GridDisplay(Header = ProjeIdHeader, Tip = "Liste", ListName = "projes", ListVisibleColumnName = "kod")] public int? projeId { get; set; }
        [GridDisplay(Header = ProjeKodHeader)] public string projekod { get; set; }
        [GridDisplay(Header = StokGrupIdHeader, Tip ="Liste",ListName = "stokGrups", ListVisibleColumnName = "ad")]public int? stokKartstokGrupId { get; set; }
        [GridDisplay(Header = MalzemeStandartdHeader, Tip = "Liste", ListName = "malzemeStandarts", ListVisibleColumnName = "ad")] public int? stokKartmalzemeStandart { get; set; }
        [GridDisplay(Header = MalzemeGrupIdHeader, Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? stokKartmalzemeGrupId { get; set; }
        [GridDisplay(Header = MalzemeAltGrupIdHeader, Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")]public int? stokKartmalzemeAltGrupId { get; set; }
        [GridDisplay(Header = MalzemeAltGrup2IdHeader, Tip = "Liste", ListName = "malzemeAltGrup2List", ListVisibleColumnName = "ad")]public int? stokKartmalzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = StokKartIdHeader, Tip = "Liste", ListName = "stokKartList", ListVisibleColumnName = "ad")]public int? stokKartId { get; set; }
        [GridDisplay(Header = OlcuBirimIdHeader, Tip = "Liste", ListName = "olcuBirims", ListVisibleColumnName = "ad")] public int? stokKartolcuBirimId { get; set; }
        [GridDisplay(Header = BoyutTanimIdHeader, Tip = "Liste", ListName = "boyutList", ListVisibleColumnName = "ad")] public int? stokKartboyutTanimId { get; set; }
        [GridDisplay(Header = StokKartKoduHeader)]public string stokKartkod { get; set; }
        [GridDisplay(Header = StokKartAdHeader)] public string stokKartad { get; set; }
        [GridDisplay(Header = StokKartBoyutHeader)] public string stokKartboyut { get; set; }
        [GridDisplay(Header = StokKartUzunlukHeader)] public double? stokKartuzunluk { get; set; }
        [GridDisplay(Header = StokKartAgirlikHeader)] public double? stokKartagirlik { get; set; }
        [GridDisplay(Header = StokKartAciklamaHeader)] public string stokKartaciklama { get; set; }
        private double? _miktar;
        [GridDisplay(Header = TalepMiktariHeader)]public double? miktar { get => _miktar; set {
                _miktar = value; OnPropertyChanged(nameof(miktar));
                OnPropertyChanged(nameof(agirlik));
            } }
        private double? _onaylananMiktar;
        [GridDisplay(Header = TalepOnaylananMiktarHeader, readOnly = false)] public double? onaylananMiktar { get => _onaylananMiktar; set
            {
                _onaylananMiktar = value; OnPropertyChanged(nameof(onaylananMiktar));
                OnPropertyChanged(nameof(agirlik));
            }
        }
        [GridDisplay(Header = AgirlikHeader)]public double? agirlik { get { return stokKartagirlik * miktar; } }
        [GridDisplay(Header = AciklamaHeader,readOnly =false)]public string aciklama { get; set; }
        [GridDisplay(Header = TalepTarihiHeader)]public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = TeslimTarihiHeader)]public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = OnaylayanHeader)]public string onayPersonelad { get; set; }
        [GridDisplay(Header = TalepEdenHeader)]public string talepEdenPersonelad { get; set; }
        [GridDisplay(Header = isTeklifHeader, Visible = false)]public bool? isTeklif { get; set; }
        private List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        [GridDisplay(Header = "Satır Detay", Visible = false)]
        public List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays
        {
            get { if (_satinalmaTalepSatirDetays == null) _satinalmaTalepSatirDetays = new List<SatinalmaTalepSatirDetay>(); return _satinalmaTalepSatirDetays; }
            set { _satinalmaTalepSatirDetays = value; }
        }

    }
    public class SatinalmaTalepDetayDTOHeader
    {
        public const string IdHeader = "Id";
        public const string TalepNoHeader = "Talep No";
        public const string ProjeIdHeader = "Proje Id";
        public const string ProjeKodHeader = "Proje Kodu";
        public const string StokKartIdHeader = "Stok Kartı";
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokKartAdHeader = "Stok Adı";
        public const string StokGrupIdHeader = "Stok Grup";
        public const string MalzemeGrupIdHeader = "Malzeme Grubu";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grubu";
        public const string MalzemeAltGrup2IdHeader = "Malzeme Alt Grubu 2";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepOnaylananMiktarHeader = "Onaylanan Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onay Personel";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Talep Detay Açıklama";
        public const string AgirlikHeader = "Ağırlık";
        public const string isTeklifHeader = "Teklif?";
        public const string TalepNedenIdHeader = "Talep Neden Id";
        public const string TalepNedenHeader = "Talep Nedeni";
        public const string MalzemeStandartdHeader = "Malzeme Standart";
        public const string StokKartBoyutHeader = "Boyut";
        public const string StokKartUzunlukHeader = "Uzunluk";
        public const string StokKartAgirlikHeader = "Stok Kart Ağırlık";
        public const string SatinalmaTalepDetayAgirlikHeader = "Toplam Ağırlık";
        public const string StokKartAciklamaHeader = "Stok Kart Açıklama";
        public const string OlcuBirimIdHeader = "Ölçü Birimi";
        public const string BoyutTanimIdHeader = "Boyut Tanım";
    }
}
