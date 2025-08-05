using Models.Attributes;
using static Models.DTO.SatinalmaTeklifDTOHeader;
namespace Models.DTO
{
    public class SatinalmaTeklifBaslikDTO:IEntity
    {
        [GridDisplay(Header = IdHdr,Visible =false)]public int? Id { get; set; }
        [GridDisplay(Header = teklifNoHdr)]public string teklifNo { get; set; }
        [GridDisplay(Header = projeIdHdr)]public int? projeId { get; set; }
        [GridDisplay(Header = parcaGrupIdHdr)]public int? parcaGrupId { get; set; }
        [GridDisplay(Header = teklifTalepTarihiHdr)]public DateTime? teklifTalepTarihi { get; set; }
        [GridDisplay(Header = terminSuresiHdr)]public int? terminSuresi { get; set; }
        [GridDisplay(Header = teklifTarihiHdr)]public DateTime? teklifTarihi { get; set; }
        [GridDisplay(Header = firmaIdHdr)]public int? teklifFirmaId { get; set; }
        [GridDisplay(Header = firmaadHdr)]public string? teklifFirmaad { get; set; }
        [GridDisplay(Header = firmamailHdr)]public string? teklifFirmamail { get; set; }
        [GridDisplay(Header = odemeVadeIdHdr)]public int? vadeId { get; set; }
        [GridDisplay(Header = odemeVadeadHdr)]public string? vadead { get; set; }
        [GridDisplay(Header = aciklamaHdr)]public string? aciklama { get; set; }
        [GridDisplay(Header = tutarHdr)]public double? teklifTutartutar { get; set; }
        [GridDisplay(Header = dovizCinsiIdHdr)]public int? teklifTutardovizCinsiId { get; set; }
        [GridDisplay(Header = teklifGecerlilikSuresiHdr)]public int? teklifGecerlilikSuresi { get; set; }
        [GridDisplay(Header = teklifDurumuIdHdr)]public int? teklifDurumuId { get; set; }
        [GridDisplay(Header = satinalmaTeklifDetayListHdr,Visible =false)]public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList { get; set; }
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
