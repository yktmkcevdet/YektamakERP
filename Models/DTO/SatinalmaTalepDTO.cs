using Models.Attributes;
using static Models.DTO.SatinalmaTalepDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTalepDTO : IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Talep No")] public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = "Talep Nedeni",Tip ="Liste",ListName ="talepNedenList",ListVisibleColumnName ="ad")] public int? talepNedenId { get; set; }
        [GridDisplay(Header = "Proje Id")] public int? projeId { get; set; }
        [GridDisplay(Header = ProjeKoduHeader)] public string projekod { get; set; }
        [GridDisplay(Header = "Set Adet")] public int? setAdet { get; set; }
        [GridDisplay(Header = StokGrupIdHeader)] public int? stokGrupId { get; set; }
        [GridDisplay(Header = MalzemeGrupIdHeader)] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = AciklamaHeader)] public string aciklama { get; set; }
        [GridDisplay(Header = TalepTarihiHeader)] public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = TeslimTarihiHeader)] public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = "Onay Kullanici Id")] public int? onayKullaniciId { get; set; }
        [GridDisplay(Header = OnaylayanHeader)] public string onayKullanicipersonelad { get; set; }
        [GridDisplay(Header = "Talep Kullanici Id")] public int? talepEdenKullaniciId { get; set; }
        [GridDisplay(Header = TalepEdenHeader)] public string talepEdenKullanicipersonelad { get; set; }

        private List<SatinalmaTalepDetay> _satinalmaTalepDetays;
        [GridDisplay(Header = "Talep Detay Listesi", Visible = false)]
        public virtual List<SatinalmaTalepDetay> satinalmaTalepDetays
        {
            get { if (_satinalmaTalepDetays == null) _satinalmaTalepDetays = new List<SatinalmaTalepDetay>(); return _satinalmaTalepDetays; }
            set { _satinalmaTalepDetays = value; }
        }

    }
    public class SatinalmaTalepDTOHeader
    {
        public const string StokKartIdHeader = "Stok Kart Id";
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokKartAdiHeader = "Stok Kart Adı";
        public const string StokGrupAdiHeader = "Stok Grubu Adı";
        public const string MalzemeGrupAdiHeader = "Malzeme Grubu Adı";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onaylayan";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Açıklama";
        public const string AgirlikHeader = "Ağırlık";
        public const string MalzemeGrupIdHeader = "Malzeme Grup Id";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grup Id";
        public const string StokGrupIdHeader = "Grup Id";
        public const string ProjeKoduHeader = "Proje Kodu";
        public const string GuncelleHeader = "Güncelle";
        public const string SilHeader = "Sil";
        public const string CheckHeader ="Seç";
    }
}
