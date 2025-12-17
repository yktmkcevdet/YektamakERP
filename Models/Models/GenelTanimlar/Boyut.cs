using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Boyut:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "kod")] public string kod { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
        [GridDisplay(Header = "Malzeme Grubu", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grubu", Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")] public int? malzemeAltGrupId { get; set; }
        public int? malzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Dosya Yolu")] public string path { get; set; }
        [GridDisplay(Header = "Klasör")] public string klasorAd { get; set; }
    }
}
