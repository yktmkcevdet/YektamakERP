using Models.Attributes;

namespace Models.DTO
{
    public class SatinalmaTalepDTO : IEntity
    {
        [GridDisplay(Header = "Id", Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Talep No", Visible = true)]
        public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = "Proje Id ", Visible = true)]
        public int? projeId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.ProjeKoduHeader, Visible = true)]
        public string projekod { get; set; }
        [GridDisplay(Header = "Set Adet", Visible = true)]
        public int? setAdet { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.StokGrupIdHeader, Visible = true)]
        public int? stokGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.MalzemeGrupIdHeader, Visible = true)]
        public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.AciklamaHeader, Visible = true)]
        public string aciklama { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepTarihiHeader, Visible = true)]
        public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TeslimTarihiHeader, Visible = true)]
        public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = "Onay Kullanici Id", Visible = true)]
        public int? onayKullaniciId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.OnaylayanHeader, Visible = true)]
        public string onayKullanicipersonelad { get; set; }
        [GridDisplay(Header = "Talep Kullanici Id", Visible = true)]
        public int? talepEdenKullaniciId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepEdenHeader, Visible = true)]
        public string talepEdenKullanicipersonelad { get; set; }
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
        public const string ProjeKoduHeader = "Stok Grubu Adı";
    }
}
