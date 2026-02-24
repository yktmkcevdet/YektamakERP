using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GridSettings:IEntity
    {
        public int? Id { get; set; }
        public string grid { get; set; }
        public int? kullaniciId { get; set; }
        public string ayar { get; set; }

    }
}
