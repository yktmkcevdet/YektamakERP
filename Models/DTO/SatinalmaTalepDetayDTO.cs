using Models.Attributes;
using static Models.DTO.SatinalmaTalepDetayDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTalepDetayDTO : IEntity
    {
        [GridDisplay(Header = IdHeader, Visible = true)] public int? Id { get; set; }
        [GridDisplay(Header = TalepNoHeader, Visible = true)]public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = ProjeIdHeader, Visible = true)]public int? projeId { get; set; }
        [GridDisplay(Header = ProjeKoduHeader, Visible = true)]public string projekod { get; set; }
        [GridDisplay(Header = StokGrupIdHeader, Visible = true)]public int? stokKartstokGrupId { get; set; }
        [GridDisplay(Header = StokGrupAdiHeader, Visible = true)]public string stokKartstokGrupad { get; set; }
        [GridDisplay(Header = MalzemeGrupIdHeader, Visible = true)]public int? stokKartmalzemeGrupId { get; set; }
        [GridDisplay(Header = MalzemeGrupAdiHeader, Visible = true)]public string stokKartmalzemeGrupad { get; set; }
        [GridDisplay(Header = MalzemeAltGrupIdHeader, Visible = true)]public int? stokKartmalzemeAltGrupId { get; set; }
        [GridDisplay(Header = MalzemeAltGrupAdiHeader, Visible = true)]public string stokKartmalzemeAltGrupad { get; set; }
        [GridDisplay(Header = MalzemeAltGrup2IdHeader, Visible = true)]public int? stokKartmalzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = MalzemeAltGrup2AdiHeader, Visible = true)]public string stokKartmalzemeAltGrup2ad { get; set; }
        [GridDisplay(Header = StokKartIdHeader, Visible = true)]public int? stokKartId { get; set; }
        [GridDisplay(Header = StokKartKoduHeader, Visible = true)]public string stokKartkod { get; set; }
        [GridDisplay(Header = StokKartAdiHeader, Visible = true)]public string stokKartad { get; set; }
        [GridDisplay(Header = TalepMiktariHeader, Visible = true)]public double? miktar { get; set; }
        [GridDisplay(Header = AgirlikHeader, Visible = true)]public double? agirlik { get; set; }
        [GridDisplay(Header = AciklamaHeader, Visible = true)]public string aciklama { get; set; }
        [GridDisplay(Header = TalepTarihiHeader, Visible = true)]public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = TeslimTarihiHeader, Visible = true)]public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = OnaylayanHeader, Visible = true)]public string onayPersonelad { get; set; }
        [GridDisplay(Header = TalepEdenHeader, Visible = true)]public string talepEdenPersonelad { get; set; }
        private List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        [GridDisplay(Header = "", Visible = false)]
        public virtual List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays
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
        public const string ProjeKoduHeader = "Proje Kodu";
        public const string StokKartIdHeader = "Stok Kart Id";
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokKartAdiHeader = "Stok Kart Adı";
        public const string StokGrupIdHeader = "Grup Id";
        public const string StokGrupAdiHeader = "Stok Grubu Adı";
        public const string MalzemeGrupIdHeader = "Malzeme Grup Id";
        public const string MalzemeGrupAdiHeader = "Malzeme Grubu Adı";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grup Id";
        public const string MalzemeAltGrupAdiHeader = "Malzeme Alt Grup Adı";
        public const string MalzemeAltGrup2IdHeader = "Malzeme Alt Grup 2 Id";
        public const string MalzemeAltGrup2AdiHeader = "Malzeme Alt Grup 2 Adı";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onaylayan";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Açıklama";
        public const string AgirlikHeader = "Ağırlık";
    }
}
