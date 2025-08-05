using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MalzemeGrup : IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        private StokGrup _stokGrup;
        public StokGrup stokGrup { get { if (_stokGrup == null) { _stokGrup = new StokGrup(); } return _stokGrup; } set { _stokGrup = value; } }
    }
}
