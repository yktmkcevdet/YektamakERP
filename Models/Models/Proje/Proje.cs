
using Models.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace Models
{
    public record Proje : IEntity
    {
        [GridDisplay(Header = "Id")]  public int? Id { get; set; }
        [GridDisplay(Header = "Proje No")] public int? projeNo { get; set; }
        [GridDisplay(Header = "Ver.")] public string? versiyon { get; set; }
        [GridDisplay(Header = "Kod")] public string kod { get => ProjeKodString();}
        private Marka _marka;
        [GridDisplay(Header = "Marka", Tip = "Liste", ListName = "markaList", ListVisibleColumnName = "ad", readOnly = false)]
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }
        public string ProjeKodString()
        {
            int repeatCount = 4 - projeNo.ToString().Length;
            if (string.IsNullOrWhiteSpace(versiyon))
            {
                return $"{marka.prefix}-{string.Concat(Enumerable.Repeat("0", repeatCount))}{projeNo.ToString()}";
            }
            else
            {
                return $"{marka.prefix}-{string.Concat(Enumerable.Repeat("0", repeatCount))}{projeNo.ToString()}-{versiyon}";
            }
        }

       
        
        private MarkaAltGrup _markaAltGrup;
        [GridDisplay(Header = "Marka Alt Grup", Tip = "Liste", ListName = "markaAltGrupList", ListVisibleColumnName = "ad", readOnly = false)]
        public MarkaAltGrup markaAltGrup { get { if (_markaAltGrup == null) { _markaAltGrup = new(); } return _markaAltGrup; } set { _markaAltGrup = value; } }

        private MarkaAltGrupKategori _markaAltGrupKategori;
        [GridDisplay(Header = "Marka Alt Grup Kategori", Tip = "Liste", ListName = "markaAltGrupKategori", ListVisibleColumnName = "ad", readOnly = false)]
        public MarkaAltGrupKategori markaAltGrupKategori { get { if (_markaAltGrupKategori == null) { _markaAltGrupKategori = new(); } return _markaAltGrupKategori; } set { _markaAltGrupKategori = value; } }


        [GridDisplay(Header = "Ad")] public string ad { get; set; }
        public string aciklama { get; set; }

        private Personel _personel;
        public Personel personel { get { if (_personel == null) { _personel = new(); } return _personel; } set { _personel = value; } }
        private ProjeTip _projeTip;
        [GridDisplay(Header = "Proje Tipi", Tip = "Liste", ListName = "projeTipList",ListVisibleColumnName ="ad",readOnly =false)]
        public ProjeTip projeTip { get { if (_projeTip == null) { _projeTip = new(); } return _projeTip; } set { _projeTip = value; } }
        
        public int? satisSiparisId { get; set; }
        public int? mirasProjeId { get; set; }
    }
    public record ProjeTip : IEntity
    {
        public int? Id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
    }
}
