using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MalzemeAltGrupDTO:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "kod")][MaxLength(4)] public string kod { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
        [GridDisplay(Header = "malzemeGrup", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Stok Grup Id", Tip = "Liste", ListName = "stokGrups", ListVisibleColumnName = "ad", readOnly = false)] public int? malzemeGrupstokGrupId { get; set; }
    }
}
