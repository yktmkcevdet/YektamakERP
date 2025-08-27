using Models.Attributes;
namespace Models.DTO
{
    public class SatinalmaTeklifBaslikDTO:IEntity
    {
        [GridDisplay(Header = "Id", Visible =false)]public int? Id { get; set; }
        [GridDisplay(Header = "Teklif No")]public string teklifNo { get; set; }
        [GridDisplay(Header = "Proje Id", Tip = "Liste", ListName = "projes", ListVisibleColumnName = "kod")]public int? projeId { get; set; }
        [GridDisplay(Header = "Parça Grup Id", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")]public int? parcaGrupId { get; set; }
        [GridDisplay(Header = "Teklif Talep Tarihi")]public DateTime? teklifTalepTarihi { get; set; }
        [GridDisplay(Header = "Termin Süresi")]public int? terminSuresi { get; set; }
        [GridDisplay(Header = "Teklif Tarihi")]public DateTime? teklifTarihi { get; set; }
        [GridDisplay(Header = "Firma Id", Tip = "Liste", ListName = "firmaList", ListVisibleColumnName = "ad")]public int? teklifFirmaId { get; set; }
        [GridDisplay(Header = "Firma Adı")]public string? teklifFirmaad { get; set; }
        [GridDisplay(Header = "Firma Maili")]public string? teklifFirmamail { get; set; }
        [GridDisplay(Header = "Ödeme Vade Id", Tip = "Liste", ListName = "vadeList", ListVisibleColumnName = "ad")]public int? vadeId { get; set; }
        [GridDisplay(Header = "Vade")]public string? vadead { get; set; }
        [GridDisplay(Header = "Açıklama")]public string? aciklama { get; set; }
        [GridDisplay(Header = "Tutar")]public double? teklifTutar { get; set; }
        [GridDisplay(Header = "Döviz Cinsi Id",Tip ="Liste",ListName ="dovizCinsiList",ListVisibleColumnName ="kod")]public int? dovizCinsiId { get; set; }
        [GridDisplay(Header = "Teklif Geçerlilik Süresi")]public int? teklifGecerlilikSuresi { get; set; }
        [GridDisplay(Header = "Teklif Durumu Id")]public int? teklifDurumuId { get; set; }
        [GridDisplay(Header = "satinalmaTeklifDetayList", Visible =false)]public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList { get; set; }
    }
}
