using Models.Attributes;
using Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MalzemeAltGrup2 : IEntity, IBaseEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header = "ad")]
        public string ad { get; set; }
        [GridDisplay(Header = "kod")]
        public string kod { get; set; }

        private MalzemeAltGrup _malzemeAltGrup;
        [GridDisplay(Header = "Malzeme Alt Grup")]
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }


        public bool isUretim;
    }
}
