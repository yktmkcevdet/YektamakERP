using Models.Attributes;

namespace Models.DTO
{
    public class SatinalmaTalepSatirDetayDTO:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Stok Kart Id")]public int? stokKartId { get; set; }
        [GridDisplay(Header = "Stok Kart Kodu")]public string stokKartkod { get; set; }
        [GridDisplay(Header = "Stok Kart Adı")]public string stokKartad { get; set; }
        [GridDisplay(Header = "Miktar")]public double? miktar { get; set; }
        [GridDisplay(Header = "Ağırlık")]public double? stokKartagirlik { get; set; }
    }
}
