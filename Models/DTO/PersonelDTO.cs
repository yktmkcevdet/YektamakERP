using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PersonelDTO: IEntity
    {
        [GridDisplay(Header ="ID", Visible = false)] public int? Id { get; set; }
        [GridDisplay(Header = "Adı", Visible = true)] public string ad { get; set; }
        [GridDisplay(Header = "Soyadı", Visible = false)] public string soyad { get; set; }
        [GridDisplay(Header = "Personel İsim", Visible = false)] public string adSoyad { get; set; }
        [GridDisplay(Header = "Telefon", Visible = true)] public string telefon { get; set; }
        [GridDisplay(Header = "mail", Visible = true)] public string mail { get; set; }
        [GridDisplay(Header = "firmaId", Visible = false)] public int? firmaId { get; set; }
        [GridDisplay(Header = "pozisyonId", Visible = false)] public int? pozisyonId { get; set; }
        [GridDisplay(Header = "yoneticiId", Visible = false)] public int? yoneticiPersonelId { get; set; }

    }
}
