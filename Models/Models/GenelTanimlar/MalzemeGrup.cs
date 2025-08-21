using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MalzemeGrup : IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header = "Kod")]
        [MaxLength(3)]
        public string kod { get; set; }
        [GridDisplay(Header = "ad")]
        public string ad { get; set; }
        
        private StokGrup _stokGrup;
        [GridDisplay(Header = "Stok Grup",readOnly =false,Tip ="Liste",ListName ="stokGrups",ListVisibleColumnName ="ad")]
        public StokGrup stokGrup { get { if (_stokGrup == null) { _stokGrup = new StokGrup(); } return _stokGrup; } set { _stokGrup = value; } }
    }
}
