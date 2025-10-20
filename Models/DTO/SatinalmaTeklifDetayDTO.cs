using Models.Attributes;

namespace Models.DTO
{
    public class SatinalmaTeklifDetayDTO:IEntity
    {
        [GridDisplay(Header = "Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Birim fiyat")]public double? tutar { get; set; }
        [GridDisplay(Header ="Döviz Cinsi",Tip ="Liste",ListName ="dovizCinsiList",ListVisibleColumnName ="kod")] public int? dovizCinsiId { get; set; }
        [GridDisplay(Header = "Talep Detay Id")]public int? satinalmaTalepDetayId { get; set; }
        [GridDisplay(Header = "Stok Kart Id")]public int? satinalmaTalepDetayprojeStokKartstokKartId { get; set; }
        [GridDisplay(Header = "Stok Kart Kod")]public string satinalmaTalepDetayprojeStokKartstokKartkod { get; set; }
        [GridDisplay(Header = "Stok Kart Ad")]public string satinalmaTalepDetayprojeStokKartstokKartad { get; set; }
        [GridDisplay(Header = "Miktar")]public double? satinalmaTalepDetaymiktar { get; set; }
        [GridDisplay(Header = "Ağırlık")]public double? satinalmaTalepDetayagirlik { get; set; }
        [GridDisplay(Header = "Talep Açıklama")]public string satinalmaTalepDetayaciklama { get; set; }
    }
}
