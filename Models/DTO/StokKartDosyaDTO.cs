using Models.Attributes;

namespace Models.DTO
{
    public class StokKartDosyaDTO:IEntity
    {
        [GridDisplay(Header = "Id")]public int Id { get; set; }
        [GridDisplay(Header = "Stok Kartı Id")]public int stokKartId { get; set; }
        [GridDisplay(Header = "Dosya Tipi", Tip = "Liste", ListVisibleColumnName = "ad", ListName = "dosyaTipList")]public int? dosyaTipId { get; set; }
        [GridDisplay(Header = "Dosya Adı")]public string dosyaAd { get; set; }
        [GridDisplay(Header = "Dosya Uzantısı")]public string dosyaUzanti { get; set; }
        [GridDisplay(Header = "Dosya")]public byte[] dosya { get; set; }
    }
}
