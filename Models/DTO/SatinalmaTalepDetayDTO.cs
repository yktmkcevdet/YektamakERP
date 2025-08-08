using Models.Attributes;
using static Models.DTO.SatinalmaTalepDetayDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTalepDetayDTO : IEntity
    {
        [GridDisplay(Header = IdHeader)] public int? Id { get; set; }
        [GridDisplay(Header = TalepNoHeader)]public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = TalepNedenHeader,Tip = "Liste", ListName = "talepNedenList", ListVisibleColumnName = "ad")] public int? talepNedenId { get; set; }
        [GridDisplay(Header = ProjeIdHeader, Tip = "Liste", ListName = "projes", ListVisibleColumnName = "kod")] public int? projeId { get; set; }
        [GridDisplay(Header = StokGrupIdHeader, Tip ="Liste",ListName = "stokGrups", ListVisibleColumnName = "ad")]public int? stokKartstokGrupId { get; set; }
        [GridDisplay(Header = MalzemeStandartdHeader, Tip = "Liste", ListName = "malzemeStandarts", ListVisibleColumnName = "ad")] public int? stokKartmalzemeStandart { get; set; }
        [GridDisplay(Header = MalzemeGrupIdHeader, Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? stokKartmalzemeGrupId { get; set; }
        [GridDisplay(Header = MalzemeAltGrupIdHeader, Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")]public int? stokKartmalzemeAltGrupId { get; set; }
        [GridDisplay(Header = MalzemeAltGrup2IdHeader, Tip = "Liste", ListName = "malzemeAltGrup2s", ListVisibleColumnName = "ad")]public int? stokKartmalzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = StokKartIdHeader, Tip = "Liste", ListName = "stokKartList", ListVisibleColumnName = "ad")]public int? stokKartId { get; set; }
        [GridDisplay(Header = StokKartKoduHeader)]public string stokKartkod { get; set; }
        [GridDisplay(Header = StokKartBoyutHeader)] public string stokKartboyut { get; set; }
        [GridDisplay(Header = StokKartUzunlukHeader)] public double? stokKartuzunluk { get; set; }
        [GridDisplay(Header = StokKartAgirlikHeader)] public double? stokKartagirlik { get; set; }
        [GridDisplay(Header = StokKartAciklamaHeader)] public string stokKartaciklama { get; set; }
        [GridDisplay(Header = TalepMiktariHeader)]public double? miktar { get; set; }
        [GridDisplay(Header = AgirlikHeader)]public double? agirlik { get; set; }
        [GridDisplay(Header = AciklamaHeader)]public string aciklama { get; set; }
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
        public const string ProjeIdHeader = "Proje Kodu";
        public const string StokKartIdHeader = "Stok Kartı";
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokGrupIdHeader = "Stok Grup";
        public const string MalzemeGrupIdHeader = "Malzeme Grubu";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grubu";
        public const string MalzemeAltGrup2IdHeader = "Malzeme Alt Grubu 2";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onay Personel";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Açıklama";
        public const string AgirlikHeader = "Ağırlık";
        public const string isTeklifHeader = "Teklif?";
        public const string TalepNedenHeader = "Talep Nedeni";
        public const string MalzemeStandartdHeader = "Malzeme Standart";
        public const string StokKartBoyutHeader = "Boyut";
        public const string StokKartUzunlukHeader = "Uzunluk";
        public const string StokKartAgirlikHeader = "Ağırlık";
        public const string SatinalmaTalepDetayAgirlikHeader = "Toplam Ağırlık";
        public const string StokKartAciklamaHeader = "Açıklama";
    }
}
