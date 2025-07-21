using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MalzemeAltGrup : IEntity
    {
        public int? Id { get; set; }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        public string kod { get; set; }
        public string ad { get; set; }
    }
}
