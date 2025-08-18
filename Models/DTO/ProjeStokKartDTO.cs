using Models.Attributes;

namespace Models.DTO
{
    public class ProjeStokKartDTO:IEntity
    {
        [GridDisplay(Header = "Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Miktar")]public double? miktar { get; set; }
        [GridDisplay(Header = "Adet")]public int? adet { get; set; }
        [GridDisplay(Header = "Proje", Tip ="Liste", ListVisibleColumnName = "kod",ListName ="projes")]public int? projeId { get; set; }
        [GridDisplay(Header = "Proje Kodu")]public string projekod { get; set; }
        [GridDisplay(Header = "Stok Kartı", Tip = "Liste", ListVisibleColumnName = "ad", ListName = "stokKartList")]public int? stokKartId { get; set; }
        [GridDisplay(Header = "Stok Kart Kod")] public string stokKartkod { get; set; }
        [GridDisplay(Header = "Stok Tipi", Tip = "Liste", ListVisibleColumnName = "ad", ListName = "stokTips")] public int? stokKartstokTipId { get; set; }
        [GridDisplay(Header = "Stok Adı")]public string stokKartad { get; set; }
        [GridDisplay(Header = "Ağırlık")]public double? stokKartagirlik { get; set; }
        [GridDisplay(Header = "Ölçü Birim Id",Tip ="Liste",ListName ="olcuBirims",ListVisibleColumnName ="ad")]public int? stokKartolcuBirimId { get; set; }
        [GridDisplay(Header = "Malzeme Standart Id")]public int? stokKartmalzemeStandartId { get; set; }
        [GridDisplay(Header = "Boyut")]public string stokKartboyut { get; set; }
        [GridDisplay(Header = "Boy")]public double? stokKartboy { get; set; }
        [GridDisplay(Header = "En")]public double? stokKarten { get; set; }
        [GridDisplay(Header = "Çap")]public double? stokKartcap { get; set; }
        [GridDisplay(Header = "Yükseklik")]public double? stokKartyukseklik { get; set; }
        [GridDisplay(Header = "Uzunluk")]public double? stokKartuzunluk { get; set; }
        [GridDisplay(Header = "Et Kalınlığı")]public double? stokKartetKalinligi { get; set; }
        [GridDisplay(Header = "Açıklama")]public string stokKartaciklama { get; set; }
        [GridDisplay(Header = "Stok Grup Id")]public int? stokKartstokGrupId { get; set; }
        [GridDisplay(Header = "Stok Grup Kodu")]public string stokKartstokGrupkod { get; set; }
        [GridDisplay(Header = "Stok Grup Adı")]public string stokKartstokGrupad { get; set; }
        [GridDisplay(Header = "Hammadde Id")]public int? stokKarthammaddeId { get; set; }
        [GridDisplay(Header = "Hammadde Kod")]public string stokKarthammaddekod { get; set; }
        [GridDisplay(Header = "Hammadde Ad")]public string stokKarthammaddead { get; set; }
        [GridDisplay(Header = "Hammadde Boyut")] public string stokKarthammaddeboyut { get; set; }
        [GridDisplay(Header = "Hammadde Uzunluk")] public double? stokKarthammaddeuzunluk { get; set; }
        [GridDisplay(Header = "Hammadde Stok Grup")] public int? stokKarthammaddestokGrupId { get; set; }
        [GridDisplay(Header = "Hammadde Malzeme Standart Id")] public int? stokKarthammaddemalzemeStandartId { get; set; }
        [GridDisplay(Header = "Hammadde Malzeme Standart")] public int? stokKarthammaddemalzemeStandartad { get; set; }
        [GridDisplay(Header = "Hammadde Malzeme Grup")] public int? stokKarthammaddemalzemeGrupId { get; set; }
        [GridDisplay(Header = "Hammadde Malzeme Alt Grup")] public int? stokKarthammaddemalzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Hammadde Ölçü Birim")] public int? stokKarthammaddeolcuBirimId { get; set; }
        [GridDisplay(Header = "isPdf")]public bool? stokKartisPdf { get; set; }
        [GridDisplay(Header = "isDxf")]public bool? stokKartisDxf { get; set; }
        [GridDisplay(Header = "isStep")] public bool? stokKartisStep { get; set; }
        [GridDisplay(Header = "isSatinalma")]public bool? stokKartisSatinalma { get; set; }
        [GridDisplay(Header = "Malzeme Grup Id")]public int? stokKartmalzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup Kodu")]public string stokKartmalzemeGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Grup Adı")]public string stokKartmalzemeGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Id")]public int? stokKartmalzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Kodu")]public string stokKartmalzemeAltGrupkod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup Adı")]public string stokKartmalzemeAltGrupad { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Id")]public int? stokKartmalzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Kodu")]public string stokKartmalzemeAltGrup2kod { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup2 Adı")]public string stokKartmalzemeAltGrup2ad { get; set; }
        [GridDisplay(Header = "Boyut Id", Tip ="Liste",ListName ="boyutList",ListVisibleColumnName ="ad")] public int? stokKartboyutTanimId { get; set; }
        [GridDisplay(Header = "Stok Kart Dosyaları")]public List<StokKartDosya> stokKartdosyaList { get; set; }
    }

}
