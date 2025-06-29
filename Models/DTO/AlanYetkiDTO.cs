using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AlanYetkiDTO:IEntity
    {
        [GridDisplay(Header =  "Id", Visible = false)]
        public int? Id { get; set; }

        [GridDisplay(Header = "Kullanıcı Id", Visible = true)]
        public int? kullaniciId {  get; set; }
        [GridDisplay(Header = "Kullanıcı Adı", Visible = true)]
        public string kullaniciAd { get; set; }
        [GridDisplay(Header = "Form Adı", Visible = true)]
        public string formAd { get; set; }
        [GridDisplay(Header = "Alan Adı", Visible = true)]
        public string alanAd { get; set; }
        [GridDisplay(Header = "Yetki", Visible = true)]
        public bool yetki { get; set; }
        public string model { get; set; }

    }
}
