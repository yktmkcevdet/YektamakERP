using Models.Attributes;

namespace Models
{
    public class SatinalmaSiparisDTO:IEntity
    {
        [GridDisplay(Header ="Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Sipariş No")] public string siparisNo { get; set; }
        [GridDisplay(Header = "Proje")] public int? projeId { get; set; }
        [GridDisplay(Header = "Malzeme Grup")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Sipariş Tarihi")] public DateTime? siparisTarihi { get; set; }
        [GridDisplay(Header = "Teslim Tarihi")] public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = "Sipariş Tutarı")] public double? tutar { get; set; }
        [GridDisplay(Header = "Döviz Cinsi")] public int? dovizCinsiId { get; set; }
        [GridDisplay(Header = "Avans")] public double? avans { get; set; }
        [GridDisplay(Header = "Avans Döviz Cinsi")] public int? avansDovizCinsiId { get; set; }
        [GridDisplay(Header = "KDV")] public int? kdvId { get; set; }
        [GridDisplay(Header = "Vade")] public int? vadeId { get; set; }
        [GridDisplay(Header = "Firma")] public int? firmaId { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "Teklif Id")] public int? satinalmaTeklifId { get; set; }
        [GridDisplay(Header = "Sipariş Detay")] public List<SatinalmaSiparisDetay> satinalmaSiparisDetayList { get; set; }
    }
}
