using Models.Attributes;

namespace Models.DTO
{
    public class SatinalmaTalepSatirDetayDTO:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Stok Kart Id")]public int? projeStokKartstokKartId { get; set; }
        [GridDisplay(Header = "Stok Kart Kodu")]public string projeStokKartstokKartkod { get; set; }
        [GridDisplay(Header = "Stok Kart Adı")]public string projeStokKartstokKartad { get; set; }
        [GridDisplay(Header = "Miktar")]public double? projeStokKartmiktar { get; set; }
        [GridDisplay(Header = "Ağırlık")]public double? projeStokKartstokKartagirlik { get; set; }
        [GridDisplay(Header = "Uzunluk")] public double? projeStokKartstokKartuzunluk { get; set; }
        [GridDisplay(Header = "Boyut")] public string projeStokKartstokKartboyut { get; set; }
    }
}
