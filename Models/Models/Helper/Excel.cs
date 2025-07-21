using System.Text.RegularExpressions;

namespace Models
{
    public class ExcelFormat
    {
        public int no { get; set; }
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
        public int? stokGrup { get; set; }
        public int? malzemeGrup { get; set; }
        public int? malzemeAltGrup { get; set; }
        public int? malzemeAltGrup2 { get; set; }
        public int? malzemeStandart { get; set; }
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
    public class ExcelGrupParametre
    {
        public string sutunAdi { get; set; }
        public string kosulMetni { get; set; }
        public int? stokGrupId {  get; set; }
        public int? malzemeGrupId { get; set; }
        public int? malzemeAltGrupId { get; set; }
        public int? malzemeAltGrup2Id { get; set; }
        public int? malzemeStandartId { get; set; }
        public string karsilastirmaKelimesi { get; set; }
        public KarsilastirmaOperatoru karsilastirmaOperatoru { get; set; }

    }
    public enum KarsilastirmaOperatoru
    {
        Contains,
        Equals,
        StartsWith,
        EndsWith,
        Count
    }
}
    

