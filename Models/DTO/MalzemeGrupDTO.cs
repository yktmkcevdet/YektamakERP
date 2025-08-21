using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MalzemeGrupDTO:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Kod")][MaxLength(3)] public string kod { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
        [GridDisplay(Header ="Stok Grup Id",Tip ="Liste",ListName ="stokGrups", ListVisibleColumnName ="ad",readOnly = false)] public int? stokGrupId { get; set; }
    }
}
