
using Models.Attributes;
using System.ComponentModel;

namespace Models
{
    public class Proje:IEntity
    {
        [FilterAttribute]
        public int? Id { get; set; }
        public int? no { get; set; }
        public string ProjeKodString()
        {
            int repeatCount = 4 - no.ToString().Length;
            return _marka.prefix + "-" + string.Concat(Enumerable.Repeat("0",repeatCount)) + no.ToString();
        }
        private Marka _marka;
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }
        
        public string kod {  get; set; }

        private Personel _personel;
        public Personel personel { get { if (_personel == null) { _personel = new(); } return _personel; } set { _personel = value; } }
        public int satisSiparisId;
    }
}