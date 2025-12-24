using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProjeDosya:IEntity
    {
        public int? Id { get; set; }
        public int projeId { get; set; }
        public string tanim { get; set; }
        public string dosyaYolu { get; set; }
        public string uzanti { get; set; }
        public string dosyaFullPath { get; set; }
        public bool active { get; set; }
        public DateTime yuklenmeTarihi { get; set; }
        private Kullanici _yukleyenKullanici;
        public Kullanici yukleyenKullanici
        {
            get
            {
                if (_yukleyenKullanici == null)
                {
                    _yukleyenKullanici = new();
                }
                return _yukleyenKullanici;
            }
            set
            {
                _yukleyenKullanici = value;
            }
        }
    }
}
