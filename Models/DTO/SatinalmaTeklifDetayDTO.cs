using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaTeklifDetayDTO:IEntity
    {
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.Id,Visible =true)]
        public int? Id { get; set; }
        
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.birimFiyattutar, Visible = true)]
        public double? birimFiyattutar { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetayId, Visible = true)]
        public int? satinalmaTalepDetayId { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetaytokKartId, Visible = true)]
        public int? satinalmaTalepDetaystokKartId { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetaytokKartkod, Visible = true)]
        public string satinalmaTalepDetaystokKartkod { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetaytokKartad, Visible = true)]
        public string satinalmaTalepDetaystokKartad { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetaymiktar, Visible = true)]
        public double? satinalmaTalepDetaymiktar { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetayagirlik, Visible = true)]
        public double? satinalmaTalepDetayagirlik { get; set; }
        [GridDisplay(Header = SatinalmaTeklifDetayDTOHeader.satinalmaTalepDetayaciklama, Visible = true)]
        public string satinalmaTalepDetayaciklama { get; set; }
    }
    public class SatinalmaTeklifDetayDTOHeader
    {
        public const string Id = "Id";
        public const string birimFiyattutar = "Birim fiyat";
        public const string satinalmaTalepDetayId = "Talep Detay Id";
        public const string satinalmaTalepDetaytokKartId = "Stok Kart Id";
        public const string satinalmaTalepDetaytokKartkod = "Stok Kart Kod";
        public const string satinalmaTalepDetaytokKartad = "Stok Kart Ad";
        public const string satinalmaTalepDetaymiktar = "Miktar";
        public const string satinalmaTalepDetayagirlik = "Ağırlık";
        public const string satinalmaTalepDetayaciklama = "Talep Açıklama";
        
    }
}
