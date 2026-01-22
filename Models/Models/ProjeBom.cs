using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProjeBom
    {
        public int? Id { get; set; }
        private Proje _proje;
        public Proje proje { get { if (_proje == null) { _proje = new(); } return _proje; } set { _proje = value; } }
        private ProjeStokKart _projeStokKart;
        public ProjeStokKart projeStokKart { get { if (_projeStokKart == null) { _projeStokKart = new(); } return _projeStokKart; } set { _projeStokKart = value; } }
        public int? adet { get; set; }
        public string no { get; set; }

    }
}
