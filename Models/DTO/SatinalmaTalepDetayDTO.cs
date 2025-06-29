using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaTalepDTO : IEntity
    {
        [GridDisplay(Header = SatinalmaTalepDTOHeader.IdHeader, Visible = true)]
        public int? Id { get; set; }
        public int? satinalmaTalepDetayId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepNoHeader, Visible = true)]
        public string satinalmaTalepNo { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.ProjeIdHeader, Visible = true)]
        public int? projeId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.ProjeKoduHeader, Visible = true)]
        public string projeKod { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.StokGrupIdHeader, Visible = true)]
        public int? stokGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.MalzemeGrupIdHeader, Visible = true)]
        public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.MalzemeAltGrupIdHeader, Visible = true)]
        public int? malzemeAltGrupId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.StokKartIdHeader, Visible = true)]
        public int? stokKartId { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.StokKartKoduHeader, Visible = true)]
        public string stokKartKod { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.StokKartAdiHeader, Visible = true)]
        public string stokKartAd { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepMiktariHeader, Visible = true)]
        public double? miktar { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.AgirlikHeader, Visible = true)]
        public double stokKartagirlik { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.AciklamaHeader, Visible = true)]
        public string aciklama { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepTarihiHeader, Visible = true)]
        public DateTime? talepTarihi { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TeslimTarihiHeader, Visible = true)]
        public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.OnaylayanHeader, Visible = true)]
        public string onayPersonelAd { get; set; }
        [GridDisplay(Header = SatinalmaTalepDTOHeader.TalepEdenHeader, Visible = true)]
        public string talepEdenPersonelAd { get; set; }
        private List<SatinalmaTalepSatirDetay> _satinalmaTalepSatirDetays;
        public virtual List<SatinalmaTalepSatirDetay> satinalmaTalepSatirDetays
        {
            get { if (_satinalmaTalepSatirDetays == null) _satinalmaTalepSatirDetays = new List<SatinalmaTalepSatirDetay>(); return _satinalmaTalepSatirDetays; }
            set { _satinalmaTalepSatirDetays = value; }
        }
        
    }
    public class SatinalmaTalepDTOHeader
    {
        public const string StokKartKoduHeader = "Stok Kart Kodu";
        public const string StokKartAdiHeader = "Stok Kart Adı";
        public const string StokGrupAdiHeader = "Stok Grubu Adı";
        public const string MalzemeGrupAdiHeader = "Malzeme Grubu Adı";
        public const string TalepMiktariHeader = "Talep Miktarı";
        public const string TalepTarihiHeader = "Talep Tarihi";
        public const string TeslimTarihiHeader = "Teslim Tarihi";
        public const string OnaylayanHeader = "Onaylayan";
        public const string TalepEdenHeader = "Talep Eden";
        public const string AciklamaHeader = "Açıklama";
        public const string AgirlikHeader = "Ağırlık";
        public const string ProjeKoduHeader = "Proje Kod";
        public const string StokKartIdHeader = "Stok Kart Id";
        public const string MalzemeGrupIdHeader = "Malzeme Grup Id";
        public const string MalzemeAltGrupIdHeader = "Malzeme Alt Grup Id";
        public const string StokGrupIdHeader = "Grup Id";
        public const string ProjeIdHeader = "Proje Id ";
        public const string TalepNoHeader = "Talep No";
        public const string IdHeader = "Id";
    }
}
