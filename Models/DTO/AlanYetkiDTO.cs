using Models.Attributes;

namespace Models.DTO
{
    public class AlanYetkiDTO:IEntity
    {
        [GridDisplay(Header =  "Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Kullanıcı Id")]public int? kullaniciId {  get; set; }
        [GridDisplay(Header = "Kullanıcı Adı")]public string kullaniciAd { get; set; }
        [GridDisplay(Header = "Form Adı")]public string formAd { get; set; }
        [GridDisplay(Header = "Alan Adı")]public string alanAd { get; set; }
        [GridDisplay(Header = "Yetki")]public bool yetki { get; set; }
        [GridDisplay(Header = "Model")]public string model { get; set; }

    }
}
