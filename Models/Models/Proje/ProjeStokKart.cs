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
        public string no { get; set; }
        public int? adet { get; set; }
        public double? miktar { get; set; }
        public string hamVeri { get; set; }
        public string pdfFileName() { return stokKart.parcaKod + ".pdf"; }
        public string dxfFileName()
        {
            if (this.stokKart.malzemeGrup.Id == 28)
            {
                string dxfAd = $@"{Regex.Escape(stokKart.parcaKod)}.*\.dxf$"; //.*{Regex.Escape(stokKart.malzeme)}_{dxfAddition()}mm.*{adet}adet
                                                                              //string dxfAd = $"{stokKart.parcaKod}*{stokKart.malzeme}_{dxfAddition()}mm*.dxf";
                return dxfAd;
            }
            return null;
        }
        public string stepFileName() { return stokKart.parcaKod + ".step"; }
        public string drwFileName() { return stokKart.parcaKod + ".SLDDRW"; }
        public string prtFileName() { return stokKart.parcaKod + ".SLDPRT"; }
        public string asmFileName() { return stokKart.parcaKod + ".SLDASM"; }
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
        
    }
}
