using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class StokKartDTO:IEntity
    {
        [GridDisplay(Header = "Stok Kart Id", Visible = false)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Stok Adı", Visible = true)]
        public string ad { get; set; }

        [GridDisplay(Header = "Stok Kodu", Visible = false)]
        public string kod { get; set; }
        
        [GridDisplay(Header = "Ağırlık", Visible = true)]
        public double? agirlik { get; set; }
        [GridDisplay(Header = "Ölçü Birim Id", Visible = true)]
        public int? olcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Standart Id", Visible = true)]
        public int? malzemeStandartId { get; set; }
        [GridDisplay(Header = "Boyut", Visible = true)]
        public string boyut { get; set; }
        [GridDisplay(Header = "Boy", Visible = true)]
        public double? boy { get; set; }
        [GridDisplay(Header = "En", Visible = true)]
        public double? en { get; set; }
        [GridDisplay(Header = "Çap", Visible = true)]
        public double? cap { get; set; }
        [GridDisplay(Header = "Yükseklik", Visible = true)]
        public double? yukseklik { get; set; }
        [GridDisplay(Header = "Uzunluk", Visible = true)]
        public double? uzunluk { get; set; }
        [GridDisplay(Header = "Et Kalınlığı", Visible = true)]
        public double? etKalinligi { get; set; }
        [GridDisplay(Header = "Açıklama", Visible = true)]
        public string aciklama { get; set; }
        [GridDisplay(Header = "Stok Grup Id", Visible = false)]
        public int? stokGrupId { get; set; }
        [GridDisplay(Header = "Stok Grup Kodu", Visible = false)]
        public string stokGrupkod { get; set; }
        [GridDisplay(Header = "Stok Grup Adı", Visible = true)]
        public string stokGrupad { get; set; }
        [GridDisplay(Header = "Stok Kart Dosyaları", Visible = false)]
        public List<StokKartDosya> dosyaList { get; set; }
        [GridDisplay(Header = "Hammadde Kod", Visible = false)]
        public string hammaddeKod { get; set; }
        [GridDisplay(Header = "isPdf", Visible = false)]
        public bool? isPdf { get; set; }
        [GridDisplay(Header = "isDxf", Visible = false)]
        public bool? isDxf { get; set; }
        [GridDisplay(Header = "isSatinalma", Visible = false)]
        public bool? isSatinalma { get; set; }
        [GridDisplay(Header = "Malzeme Grup Id", Visible = false)]
        public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup Kodu", Visible = false)]
        public string malzemeGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Grup Adı", Visible = true)]
        public string malzemeGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Id", Visible = false)]
        public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Kodu", Visible = false)]
        public string malzemeAltGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Adı", Visible = true)]
        public string malzemeAltGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Id", Visible = false)]
        public int? malzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Kodu", Visible = false)]
        public string malzemeAltGrup2kod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Adı", Visible = true)]
        public string malzemeAltGrup2ad { get; set; }
    }
}
