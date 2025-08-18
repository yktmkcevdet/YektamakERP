using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StokGrup : IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header = "kod")]
        public string kod { get; set; }
        [GridDisplay(Header = "ad")]
        public string ad { get; set; }
    }
}
