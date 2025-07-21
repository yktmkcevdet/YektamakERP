using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AlanYetki:IEntity
    {
        public int? Id { get; set; }
        private Kullanici _kullanici;
        public Kullanici kullanici
        {
            get
            {
                if (_kullanici == null)
                    _kullanici = new Kullanici();
                return _kullanici;
            }
            set
            {
                _kullanici = value;
            }
        }
        public string formAd { get; set; }
        public string alanAd { get; set; }
        public bool yetki { get; set; }
        public string model { get; set; }
    }
}
