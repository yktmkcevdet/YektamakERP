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
        [GridDisplay(Header = "Id", Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "kod", Visible = true)]
        public string kod { get; set; }
        [GridDisplay(Header = "ad", Visible = true)]
        public string ad { get; set; }
        public string sifre { get; set; }
        public string salt { get; set; }
        public int? personelId { get; set; }
        public string personelad { get; set; }
        public int? rolId { get; set; }
        public string rolad { get; set; }
        public bool? isSifreDegisti { get; set; }
    }
}
