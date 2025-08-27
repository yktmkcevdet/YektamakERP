using Models.Attributes;

namespace Models.DTO
{
    public record SatinalmaSiparisDetayDTO:IEntity
    {
        [GridDisplay(Header ="Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Sipariş Başlık Id")] public int? satinalmaSiparisBaslikId { get; set; }
        [GridDisplay(Header = "Stok Kart", Tip ="Liste", ListName ="stokKartList", ListVisibleColumnName ="ad")] public int? stokKartId { get; set; }
        [GridDisplay(Header = "miktar")] public double? miktar { get; set; }
        [GridDisplay(Header = "Birim Fiyat")] public double? birimFiyat { get; set; }
        [GridDisplay(Header = "Döviz Cinsi", Tip = "Liste", ListName = "dovizCinsiList", ListVisibleColumnName = "ad")] public int? dovizCinsiId { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "KDV", Tip = "Liste", ListName = "kdvList", ListVisibleColumnName = "oran")] public double? kdv { get; set; }
    }
}
