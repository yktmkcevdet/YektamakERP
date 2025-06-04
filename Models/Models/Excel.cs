using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ExcelParcaListesi
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

    }
    public static class ExcelMalzemeGrup
    {
        public static int stokGrup(string aciklama, string boyut, string malzeme)
        {
            if (aciklama.Contains("PROFİL", StringComparison.OrdinalIgnoreCase) || aciklama == "L" || aciklama == "LT" || aciklama == "LB" || aciklama == "LBT" || aciklama == "T" || aciklama == "P" || aciklama == "PT")
            {
                return 1; //METAL
            }
            else if (aciklama == "MATBAA")
            {
                return 6; //MATBAA
            }
            return 3; //HIRDAVAT
        }
        public static int malzemeGrup(string aciklama, string boyut, string malzeme)
        {
            if (aciklama == "L" || aciklama == "LT" || aciklama == "LB" || aciklama == "LBT")
            {
                return 28; //LAZER
            }
            if (aciklama.Contains("PROFİL", StringComparison.OrdinalIgnoreCase) || aciklama == "P" || aciklama == "PT")
            {
                return 29; //PROFİL
            }
            if (aciklama == "T" || aciklama == "STD+T")
            {
                return 30; //TALAŞLI
            }
            return 40; //MEKANİK EKİPMAN --DİĞER GRUPLAMALAR YAPILMALI (AKTARMA ELEMANLARI, SÜSPANSİYON, YAY)
        }
        public static int? malzemeAltGrup(string aciklama, string boyut, string malzeme)
        {
            if (malzemeGrup(aciklama, boyut, malzeme) == 29)
            {
                if (boyut.Count(c => c == 'Ø') == 2)
                {
                    return 44; //BORU PROFİL
                }
                if (boyut.Contains("HEA", StringComparison.OrdinalIgnoreCase))
                {
                    return 45; //HEA PROFİL
                }
                if (boyut.Contains("HEB", StringComparison.OrdinalIgnoreCase))
                {
                    return 46; //HEB PROFİL
                }
                if (boyut.Contains("IPE", StringComparison.OrdinalIgnoreCase))
                {
                    return 47; //IPE PROFİL
                }
                if (boyut.Contains("NPI", StringComparison.OrdinalIgnoreCase))
                {
                    return 50; //NPI PROFİL
                }
                if (boyut.Contains("NPU", StringComparison.OrdinalIgnoreCase))
                {
                    return 51; //NPU PROFİL
                }
                if (boyut.StartsWith("L"))
                {
                    return 49; //L KÖŞEBENT
                }
                return 48; //KUTU PROFİL
            }
            else if (malzemeGrup(aciklama, boyut, malzeme) == 28)
            {
                if (aciklama == "LB" && boyut.Count(c => c == 'Ø') == 1)
                {
                    return 39; //LAZER BÜKÜM
                }
                if (aciklama == "LBT" && boyut.Count(c => c == 'Ø') == 1)
                {
                    return 40; //LAZER BÜKÜM TALAŞLI
                }
                if (aciklama == "LT" && boyut.Count(c => c == 'Ø') == 1)
                {
                    return 43; //LAZER TALAŞLI
                }
                else
                {
                    return 38; //LAZER
                }
            }
            else if (malzemeGrup(aciklama, boyut, malzeme) == 30)
            {
                if (boyut.Count(c => c == 'Ø') == 1)
                {
                    return 55; //MİL
                }
                else
                {
                    return 56; //LAMA
                }
            }
            return null;
        }
        public static int? malzemeAltGrup2(string aciklama, string boyut, string malzeme)
        {
            if (malzemeGrup(aciklama, boyut, malzeme) == 56)
            {
                if (malzeme.Contains("SICAK", StringComparison.OrdinalIgnoreCase))
                {
                    return 162; //SICAK LAMA
                }
                if (malzeme.Contains("SOĞUK", StringComparison.OrdinalIgnoreCase))
                {
                    return 163; //SOĞUK LAMA
                }
            }
            return null;
        }
        public static (double uzunluk, string boyutText) Boyut(string metin)
        {
            Match match = Regex.Match(metin, @"L:\s*(\d+)");
            if (match.Success)
            {
                double uzunluk = Double.TryParse(match.Groups[1].Value,out double uzn)?uzn:0; // "60"

                // L: ifadesinin başladığı indeksi bul
                int lIndex = match.Index;

                // L:'den önceki kısmı al
                string boyutText = metin.Substring(0, lIndex).TrimEnd(',', ' ');
                boyutText=Regex.Replace(boyutText, @"(\d+)\.0\b", "$1");
                return (uzunluk, boyutText);
            }
            else
            {
                metin = Regex.Replace(metin, @"(\d+)\.0\b", "$1");
                return (0, metin); // eşleşme yoksa tüm metni döndür
            }
        }
    }
}
