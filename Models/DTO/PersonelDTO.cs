using Models.Attributes;

namespace Models.DTO
{
    public class PersonelDTO: IEntity
    {
        [GridDisplay(Header ="ID")] public int? Id { get; set; }
        [GridDisplay(Header = "Adı")] public string ad { get; set; }
        [GridDisplay(Header = "Soyadı")] public string soyad { get; set; }
        [GridDisplay(Header = "Personel İsim")] public string adSoyad { get; set; }
        [GridDisplay(Header = "Telefon")] public string telefon { get; set; }
        [GridDisplay(Header = "mail")] public string mail { get; set; }
        [GridDisplay(Header = "firmaId")] public int? firmaId { get; set; }
        [GridDisplay(Header = "pozisyonId")] public int? pozisyonId { get; set; }
        [GridDisplay(Header = "yoneticiId")] public int? yoneticiPersonelId { get; set; }

    }
}
