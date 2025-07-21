using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class KullaniciDTO:IEntity
    {
        [GridDisplay(Header = "Id", Visible = true)] public int? Id { get; set; }
        [GridDisplay(Header = "kod", Visible = true)] public string kod { get; set; }
        [GridDisplay(Header = "ad", Visible = true)] public string ad { get; set; }
        [GridDisplay(Header = "Personel Id", Visible = false)] public int? personelId { get; set; }
        [GridDisplay(Header = "Personel ad", Visible = false)] public string personeladSoyad { get; set; }
        [GridDisplay(Header = "Rol Id", Visible = false)] public int? rolId { get; set; }
        [GridDisplay(Header = "Rol ad", Visible = false)] public string rolad { get; set; }
        [GridDisplay(Header = "Şifre değiştir", Visible = false)] public bool? isSifreDegisti { get; set; }
    }
}
