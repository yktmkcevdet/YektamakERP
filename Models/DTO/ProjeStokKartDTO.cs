using Models.Attributes;
using System.ComponentModel;

namespace Models.DTO
{
    public class ProjeStokKartDTO:IEntity
    {
        [GridDisplay(Header = "Id", Visible = false)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Proje Id", Visible = false)]
        public int? projeId { get; set; }
        [GridDisplay(Header = "Kod", Visible = true)]
        public string projekod { get; set; }
        [GridDisplay(Header = "Stok Kart Id", Visible = false)]
        public int? stokKartId { get; set; }
        [GridDisplay(Header = "Stok Adı", Visible = true)]
        public string stokKartad { get; set; }

        [GridDisplay(Header = "Stok Kodu", Visible = true)]
        public string stokKartkod { get; set; }
        [GridDisplay(Header = "Miktar", Visible = true)]
        public double? miktar { get; set; }
        [GridDisplay(Header = "Adet", Visible = true)]
        public int? adet { get; set; }
        [GridDisplay(Header = "Ağırlık", Visible = true)]
        public double? stokKartagirlik { get; set; }
        [GridDisplay(Header = "Ölçü Birim Id", Visible = true)]
        public int? stokKartolcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Standart Id", Visible = true)]
        public int? stokKartmalzemeStandartId { get; set; }
        [GridDisplay(Header = "Boyut", Visible = true)]
        public string stokKartboyut { get; set; }
        [GridDisplay(Header = "Boy", Visible = true)]
        public double? stokKartboy { get; set; }
        [GridDisplay(Header = "En", Visible = true)]
        public double? stokKarten { get; set; }
        [GridDisplay(Header = "Çap", Visible = true)]
        public double? stokKartcap { get; set; }
        [GridDisplay(Header = "Yükseklik", Visible = true)]
        public double? stokKartyukseklik { get; set; }
        [GridDisplay(Header = "Uzunluk", Visible = true)]
        public double? stokKartuzunluk { get; set; }
        [GridDisplay(Header = "Et Kalınlığı", Visible = true)]
        public double? stokKartetKalinligi { get; set; }
        [GridDisplay(Header = "Açıklama", Visible = true)]
        public string stokKartaciklama { get; set; }
        [GridDisplay(Header = "Stok Grup Id", Visible = false, Tip ="Liste",ListName = "stokGrups", ListVisibleColumnName = "ad")]
        public int? stokKartstokGrupId { get; set; }
        [GridDisplay(Header = "Stok Grup Kodu", Visible = false)]
        public string stokKartstokGrupkod { get; set; }
        [GridDisplay(Header = "Stok Grup Adı", Visible = true)]
        public string stokKartstokGrupad { get; set; }
        [GridDisplay(Header = "Stok Kart Dosyaları", Visible = false)]
        public List<StokKartDosya> stokKartdosyaList { get; set; }
        [GridDisplay(Header = "Hammadde Id", Visible = false)]
        public int? stokKarthammaddeId { get; set; }
        [GridDisplay(Header = "Hammadde Kod", Visible = false)]
        public string stokKarthammaddekod { get; set; }
        [GridDisplay(Header = "Hammadde Ad", Visible = false)]
        public string stokKarthammaddead { get; set; }
        [GridDisplay(Header = "isPdf", Visible = false)]
        public bool? stokKartisPdf { get; set; }
        [GridDisplay(Header = "isDxf", Visible = false)]
        public bool? stokKartisDxf { get; set; }
        [GridDisplay(Header = "isSatinalma", Visible = false)]
        public bool? stokKartisSatinalma { get; set; }
        [GridDisplay(Header = "Malzeme Grup Id", Visible = false)]
        public int? stokKartmalzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup Kodu", Visible = false)]
        public string stokKartmalzemeGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Grup Adı", Visible = true)]
        public string stokKartmalzemeGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Id", Visible = false)]
        public int? stokKartmalzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Kodu", Visible = false)]
        public string stokKartmalzemeAltGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Adı", Visible = true)]
        public string stokKartmalzemeAltGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Id", Visible = false)]
        public int? stokKartmalzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Kodu", Visible = false)]
        public string stokKartmalzemeAltGrup2kod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Adı", Visible = true)]
        public string stokKartmalzemeAltGrup2ad { get; set; }
    }
    
}
