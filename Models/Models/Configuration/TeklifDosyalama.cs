using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configuration
{
    public class DosyalamaYapisi:IEntity
    {
        public int Id { get; set; }
        public int? stokGrupId { get; set; }
        public int? malzemeGrupId { get; set; }
        public int? malzemeAltGrupId { get; set; }
        public int? boyutId { get; set; }
        public string path { get; set; }
        public string klasorAd { get; set; }
        public bool dxf { get; set; }
        public bool pdf { get; set; }
        public bool step { get; set; }
    }
}
