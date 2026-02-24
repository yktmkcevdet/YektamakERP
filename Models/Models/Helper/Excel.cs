using Models.Attributes;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Models
{
    public class ExcelFormat:IEntity
    {
        public string no { get; set; }
        public string kod { get; set; }
        public string parcaAdi { get; set; }
        public int miktar { get; set; }
        public int adet { get; set; }
        public int fark { get; set; }
        public string boyut { get; set; }
        public Double uzunluk { get; set; }
        public string malzeme { get; set; }
        public string aciklama { get; set; }
        public double agirlik { get; set; }
        public int? stokTip { get; set; }
        public int? stokGrup { get; set; }
        public int? malzemeGrup { get; set; }
        public int? malzemeAltGrup { get; set; }
        public int? malzemeAltGrup2 { get; set; }
        public int? malzemeStandart { get; set; }
        public bool? isTalasli {  get; set; }
        public bool? isBukum { get; set; }
        public (double uzunluk, string boyutText) Boyut()
        {
            Match match = Regex.Match(boyut, @"L:\s*(\d+)");
            if (match.Success)
            {
                double uzunluk = Double.TryParse(match.Groups[1].Value, out double uzn) ? uzn : 0; // "60"

                // L: ifadesinin başladığı indeksi bul
                int lIndex = match.Index;

                // L:'den önceki kısmı al
                string boyutText = boyut.Substring(0, lIndex).TrimEnd(',', ' ');
                boyutText = Regex.Replace(boyutText, @"(\d+)\.0\b", "$1");
                return (uzunluk, boyutText);
            }
            else
            {
                boyut = Regex.Replace(boyut, @"(\d+)\.0\b", "$1");
                return (0, boyut); // eşleşme yoksa tüm metni döndür
            }
        }
    }
    public class ExcelGrupParametre:IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Excel Sütun Adı")]public ExcelSutunlari? sutunAdi { get; set; }
        [GridDisplay(Header = "Koşul Metni")] public string kosulMetni { get; set; }
        [GridDisplay(Header = "Stok Tipi",Tip ="Liste",ListName ="stokTips",ListVisibleColumnName ="ad")] public int? stokTipId { get; set; }
        [GridDisplay(Header = "Stok Grup", Tip = "Liste", ListName = "stokGrups", ListVisibleColumnName = "ad")] public int? stokGrupId {  get; set; }
        [GridDisplay(Header = "Malzeme Grup", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup", Tip = "Liste", ListName = "malzemeAltGrups", ListVisibleColumnName = "ad")] public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Alt Grup 2", Tip = "Liste", ListName = "malzemeAltGrup2List", ListVisibleColumnName = "ad")] public int? malzemeAltGrup2Id { get; set; }
        [GridDisplay(Header = "Malzeme Standart", Tip = "Liste", ListName = "malzemeStandarts", ListVisibleColumnName = "ad")] public int? malzemeStandartId { get; set; }
        [GridDisplay(Header = "Talaşlı?")] public bool? isTalasli {  get; set; }
        [GridDisplay(Header = "Büküm?")] public bool? isBukum { get; set; }
        [GridDisplay(Header = "Anahtar Kelime")] public string karsilastirmaKelimesi { get; set; }
        [GridDisplay(Header = "Karşılaştırma Op")] public KarsilastirmaOperatoru? karsilastirmaOperatoru { get; set; }
        
    }
    public enum KarsilastirmaOperatoru
    {
        Contains=0,
        Equals=1,
        StartsWith=2,
        EndsWith=3,
        Count=4
    }
    public enum ExcelSutunlari
    {
        aciklama=0,
        boyut=1,
        parcaAdi=2,
        no =3,
        kod =4,
        miktar=5,
        adet=6,
        fark=7,
        uzunluk=8,
        malzeme=9,
        agirlik=10
    }
}
    

