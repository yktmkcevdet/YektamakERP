using Models.Attributes;
using static Models.DTO.SatinalmaTeklifDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTeklifBaslikDTO:IEntity
    {
        [GridDisplay(Header = IdHdr,Visible =true)]public int? Id { get; set; }
        [GridDisplay(Header = teklifNoHdr, Visible = true)]public string teklifNo { get; set; }
        [GridDisplay(Header = projeIdHdr, Visible = true)]public int? projeId { get; set; }
        [GridDisplay(Header = parcaGrupIdHdr, Visible = true)]public int? parcaGrupId { get; set; }
        [GridDisplay(Header = teklifTalepTarihiHdr, Visible = true)]public DateTime? teklifTalepTarihi { get; set; }
        [GridDisplay(Header = terminSuresiHdr, Visible = true)]public int? terminSuresi { get; set; }
        [GridDisplay(Header = teklifTarihiHdr, Visible = true)]public DateTime? teklifTarihi { get; set; }
        [GridDisplay(Header = firmaIdHdr, Visible = true)]public int? teklifFirmaId { get; set; }
        [GridDisplay(Header = firmaadHdr, Visible = true)]public string? teklifFirmaad { get; set; }
        [GridDisplay(Header = firmamailHdr, Visible = true)]public string? teklifFirmamail { get; set; }
        [GridDisplay(Header = odemeVadeIdHdr, Visible = true)]public int? vadeId { get; set; }
        [GridDisplay(Header = odemeVadeadHdr, Visible = true)]public string? vadead { get; set; }
        [GridDisplay(Header = aciklamaHdr, Visible = true)]public string? aciklama { get; set; }
        [GridDisplay(Header = tutarHdr, Visible = true)]public double? teklifTutartutar { get; set; }
        [GridDisplay(Header = dovizCinsiIdHdr, Visible = true)]public int? teklifTutardovizCinsiId { get; set; }
        [GridDisplay(Header = teklifGecerlilikSuresiHdr, Visible = true)]public int? teklifGecerlilikSuresi { get; set; }
        [GridDisplay(Header = teklifDurumuIdHdr, Visible = true)]public int? teklifDurumuId { get; set; }
        [GridDisplay(Header = satinalmaTeklifDetayListHdr, Visible = true)]public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList { get; set; }
    }
    public class  SatinalmaTeklifDTOHeader
    {
        public const string IdHdr = "Id";
        public const string projeIdHdr = "Proje Id";
        public const string parcaGrupIdHdr = "Parça Grup Id";
        public const string teklifTalepTarihiHdr = "Teklif Talep Tarihi";
        public const string terminSuresiHdr = "Termin Süresi";
        public const string teklifTarihiHdr = "Teklif Tarihi";
        public const string firmaIdHdr = "Firma Id";
        public const string odemeVadeIdHdr = "Ödeme Vade Id";
        public const string aciklamaHdr = "Açıklama";
        public const string tutarHdr = "Tutar";
        public const string dovizCinsiIdHdr = "Döviz Cinsi Id";
        public const string teklifGecerlilikSuresiHdr = "Teklif Geçerlilik Süresi";
        public const string teklifDurumuIdHdr = "Teklif Durumu Id";
        public const string firmaadHdr = "Firma Adı";
        public const string firmamailHdr = "Firma Maili";
        public const string satinalmaTeklifDetayListHdr = "satinalmaTeklifDetayList";
        public const string teklifNoHdr = "Teklif No";
        public const string odemeVadeadHdr = "Vade";
    }
}
