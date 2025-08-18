using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Boyut:IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        public int? malzemeGrupId { get; set; }
        public int? malzemeAltGrupId { get; set; }
        public int? malzemeAltGrup2Id { get; set; }
    }
}
