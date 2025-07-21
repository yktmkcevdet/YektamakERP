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
        public int? Id { get; set; }
        public string ad { get; set; }
        public string kod { get; set; }
        private MalzemeAltGrup _malzemeAltGrup;
        public MalzemeAltGrup malzemeAltGrup { get { if (_malzemeAltGrup == null) { _malzemeAltGrup = new MalzemeAltGrup(); } return _malzemeAltGrup; } set { _malzemeAltGrup = value; } }


        public bool isUretim;
    }
}
