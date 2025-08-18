using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public record ProjeStokKart:IEntity
    {
        public int? Id { get; set; }
        private Proje _proje;
        public Proje proje { get { if (_proje == null) { _proje = new(); } return _proje; } set{ _proje = value; } }
        private StokKart _stokKart;
        public StokKart stokKart { get { if (_stokKart == null) { _stokKart = new(); } return _stokKart; } set { _stokKart = value; } }
        public int? adet { get; set; }
        public double? miktar { get; set; }
        public string pdfFileName() { return stokKart.parcaKod + ".pdf"; }
        public string dxfFileName()
        {
            string dxfAd = $@"{Regex.Escape(stokKart.parcaKod)}.*{Regex.Escape(stokKart.malzeme)}_{dxfAddition()}mm.*{adet}adet.*\.dxf$";
            //string dxfAd = $"{stokKart.parcaKod}*{stokKart.malzeme}_{dxfAddition()}mm*.dxf";
            return dxfAd;
        }
        public string stepFileName() { return stokKart.parcaKod + ".step"; }
        public string dxfAddition()
        {
            string pattern = @"(\d+(?:\.\d+)?)"; // Sayısal kısmı yakalayan desen

            // Regex ile eşleşmeyi bul
            Match match = Regex.Match(stokKart.boyut, pattern);
            if (match.Success)
            {
                string result = match.Groups[1].Value; // Tam sayı kısmını al
                return result;
            }
            return "";
        }
        string FormatKod(string kod, int spc)
        {
            return string.IsNullOrWhiteSpace(kod) ? "0".PadLeft(spc, '0') : kod.PadLeft(spc, '0');
        }
        public string hammaddeKod
        {
            get
            {
                return string.Join("_",
                FormatKod(stokKart.stokGrup.kod, 2),
                FormatKod(stokKart.malzemeGrup.kod, 3),
                FormatKod(stokKart.malzemeAltGrup.kod, 4),
                string.Join("", FormatKod(stokKart.malzemeAltGrup2.kod, 1),
                FormatKod(stokKart.boyut, 2),
                FormatKod(stokKart.malzeme, 2)));
            }
        }
    }
}
