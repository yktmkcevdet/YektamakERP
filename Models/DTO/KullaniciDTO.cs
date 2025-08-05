using Models.Attributes;

namespace Models.DTO
{
    public class KullaniciDTO:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "kod")] public string kod { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
        [GridDisplay(Header = "Personel Id")] public int? personelId { get; set; }
        [GridDisplay(Header = "Personel ad")] public string personeladSoyad { get; set; }
        [GridDisplay(Header = "Rol Id")] public int? rolId { get; set; }
        [GridDisplay(Header = "Rol ad")] public string rolad { get; set; }
        [GridDisplay(Header = "Şifre değiştir")] public bool? isSifreDegisti { get; set; }
    }
}
