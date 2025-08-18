
using Models.Attributes;

namespace Models
{
    public record Proje : IEntity
    {
        [FilterAttribute]
        public int? Id { get; set; }
        public int? projeNo { get; set; }
        public string versiyon { get; set; }
        public string ProjeKodString()
        {
            int repeatCount = 4 - projeNo.ToString().Length;
            return _marka.prefix + "-" + string.Concat(Enumerable.Repeat("0", repeatCount)) + projeNo.ToString();
        }
        private Marka _marka;
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }

        public string kod { get; set; }

        private Personel _personel;
        public Personel personel { get { if (_personel == null) { _personel = new(); } return _personel; } set { _personel = value; } }
        private ProjeTip _projeTip;
        public ProjeTip projeTip { get { if (_projeTip == null) { _projeTip = new(); } return _projeTip; } set { _projeTip = value; } }
        private MarkaAltGrup _markaAltGrup;
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }
        private MarkaAltGrupKategori _markaAltGrupKategori;
        public MarkaAltGrupKategori markaAltGrupKategori { get { if (_markaAltGrupKategori == null) { _markaAltGrupKategori = new(); } return _markaAltGrupKategori; } set { _markaAltGrupKategori = value; } }
        public int? satisSiparisId;
    }
    public record ProjeTip : IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
    }
}
