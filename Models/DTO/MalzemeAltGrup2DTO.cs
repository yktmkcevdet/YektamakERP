using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MalzemeAltGrup2DTO:IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header = "ad")]
        public string ad { get; set; }
        [GridDisplay(Header = "kod")]
        public string kod { get; set; }
        [GridDisplay(Header = "Stok Grup",Tip ="Liste",ListName ="stokGrups",ListVisibleColumnName ="ad")]
        public int? malzemeAltGrupmalzemeGrupstokGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")]
        public int? malzemeAltGrupmalzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup", Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")]
        public int? malzemeAltGrupId { get; set; }
    }
}
