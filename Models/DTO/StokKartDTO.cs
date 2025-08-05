using Models.Attributes;

namespace Models.DTO
{
    public class StokKartDTO:IEntity
    {
        [GridDisplay(Header = "Stok Kart Id", Visible = false)]public int? Id { get; set; }
        [GridDisplay(Header = "Stok Adı")]public string ad { get; set; }
        [GridDisplay(Header = "Stok Kodu", Visible = false)]public string kod { get; set; }
        [GridDisplay(Header = "Ağırlık")]public double? agirlik { get; set; }
        [GridDisplay(Header = "Ölçü Birim Id")]public int? olcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Standart Id")]public int? malzemeStandartId { get; set; }
        [GridDisplay(Header = "Boyut")]public string boyut { get; set; }
        [GridDisplay(Header = "Boy")]public double? boy { get; set; }
        [GridDisplay(Header = "En")]public double? en { get; set; }
        [GridDisplay(Header = "Çap")]public double? cap { get; set; }
        [GridDisplay(Header = "Yükseklik")]public double? yukseklik { get; set; }
        [GridDisplay(Header = "Uzunluk")]public double? uzunluk { get; set; }
        [GridDisplay(Header = "Et Kalınlığı")]public double? etKalinligi { get; set; }
        [GridDisplay(Header = "Açıklama")]public string aciklama { get; set; }
        [GridDisplay(Header = "Stok Tip Id", Visible = false)]public int? stokTipId { get; set; }
        [GridDisplay(Header = "Stok Grup Id", Visible = false)]public int? stokGrupId { get; set; }
        [GridDisplay(Header = "Stok Grup Kodu", Visible = false)]public string stokGrupkod { get; set; }
        [GridDisplay(Header = "Stok Grup Adı")]public string stokGrupad { get; set; }
        [GridDisplay(Header = "Stok Kart Dosyaları", Visible = false)]public List<StokKartDosya> dosyaList { get; set; }
        [GridDisplay(Header = "Hammadde Kod", Visible = false)]public string hammaddeKod { get; set; }
        [GridDisplay(Header = "isPdf", Visible = false)]public bool? isPdf { get; set; }
        [GridDisplay(Header = "isDxf", Visible = false)]public bool? isDxf { get; set; }
        [GridDisplay(Header = "isSatinalma", Visible = false)]public bool? isSatinalma { get; set; }
        [GridDisplay(Header = "Malzeme Grup Id", Visible = false)]public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup Kodu", Visible = false)]public string malzemeGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Grup Adı")]public string malzemeGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Id", Visible = false)]public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Kodu", Visible = false)]public string malzemeAltGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Adı")]public string malzemeAltGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Id", Visible = false)]public int? malzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Kodu", Visible = false)]public string malzemeAltGrup2kod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Adı")]public string malzemeAltGrup2ad { get; set; }
    }
}
