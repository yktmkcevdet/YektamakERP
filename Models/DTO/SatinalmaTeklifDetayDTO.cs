using Models.Attributes;
using static Models.DTO.SatinalmaTeklifDetayDTOHeader;

namespace Models.DTO
{
    public class SatinalmaTeklifDetayDTO:IEntity
    {
        [GridDisplay(Header = hId)]public int? Id { get; set; }
        
        [GridDisplay(Header = hbirimFiyattutar)]public double? birimFiyattutar { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetayId)]public int? satinalmaTalepDetayId { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetaytokKartId)]public int? satinalmaTalepDetaystokKartId { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetaytokKartkod)]public string satinalmaTalepDetaystokKartkod { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetaytokKartad)]public string satinalmaTalepDetaystokKartad { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetaymiktar)]public double? satinalmaTalepDetaymiktar { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetayagirlik)]public double? satinalmaTalepDetayagirlik { get; set; }
        [GridDisplay(Header = hsatinalmaTalepDetayaciklama)]public string satinalmaTalepDetayaciklama { get; set; }
    }
    public class SatinalmaTeklifDetayDTOHeader
    {
        public const string hId = "Id";
        public const string hbirimFiyattutar = "Birim fiyat";
        public const string hsatinalmaTalepDetayId = "Talep Detay Id";
        public const string hsatinalmaTalepDetaytokKartId = "Stok Kart Id";
        public const string hsatinalmaTalepDetaytokKartkod = "Stok Kart Kod";
        public const string hsatinalmaTalepDetaytokKartad = "Stok Kart Ad";
        public const string hsatinalmaTalepDetaymiktar = "Miktar";
        public const string hsatinalmaTalepDetayagirlik = "Ağırlık";
        public const string hsatinalmaTalepDetayaciklama = "Talep Açıklama";
        
    }
}
