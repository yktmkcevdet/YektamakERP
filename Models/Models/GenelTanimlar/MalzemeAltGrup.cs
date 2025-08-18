using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MalzemeAltGrup : IEntity
    {
        [GridDisplay(Header ="Id")] public int? Id { get; set; }
        private MalzemeGrup _malzemeGrup;
        [GridDisplay(Header = "malzemeGrup",Tip ="Liste",ListName ="malzemeGrups",ListVisibleColumnName ="ad")] public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        [GridDisplay(Header = "kod")] public string kod { get; set; }
        [GridDisplay(Header = "ad")] public string ad { get; set; }
    }
}
