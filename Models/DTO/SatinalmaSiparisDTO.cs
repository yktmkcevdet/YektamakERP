using Models.Attributes;
using System.ComponentModel;

namespace Models
{
    public class SatinalmaSiparisDTO:IEntity
    {
        [GridDisplay(Header ="Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Sipariş No")] public string siparisNo { get; set; }
        [GridDisplay(Header = "Proje",ListName ="projeList",Tip ="Liste",ListVisibleColumnName ="kod")] public int? projeId { get; set; }
        [GridDisplay(Header = "Malzeme Grup", ListName = "malzemeGrups", Tip = "Liste", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Sipariş Tarihi")] public DateTime? siparisTarihi { get; set; }
        [GridDisplay(Header = "Teslim Tarihi")] public DateTime? teslimTarihi { get; set; }
        [GridDisplay(Header = "Sipariş Tutarı")] public double? tutar { get; set; }
        [GridDisplay(Header = "Döviz Cinsi", ListName = "dovizCinsiList", Tip = "Liste", ListVisibleColumnName = "kod")] public int? dovizCinsiId { get; set; }
        [GridDisplay(Header = "Avans")] public double? avans { get; set; }
        [GridDisplay(Header = "Avans Döviz Cinsi")] public int? avansDovizCinsiId { get; set; }
        [GridDisplay(Header = "KDV", ListName = "kdvList", Tip = "Liste", ListVisibleColumnName = "oran")] public int? kdvId { get; set; }
        [GridDisplay(Header = "Vade", ListName = "vadeList", Tip = "Liste", ListVisibleColumnName = "ad")] public int? vadeId { get; set; }
        [GridDisplay(Header = "Firma", ListName = "firmaList", Tip = "Liste", ListVisibleColumnName = "ad")] public int? firmaId { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "Teklif Id")] public int? satinalmaTeklifId { get; set; }
        private List<SatinalmaSiparisDetay> _satinalmaSiparisDetay = new List<SatinalmaSiparisDetay>();
        [GridDisplay(Header = "Sipariş Detay")] public List<SatinalmaSiparisDetay> satinalmaSiparisDetay { get { if (_satinalmaSiparisDetay == null) { _satinalmaSiparisDetay = new(); } return _satinalmaSiparisDetay; } set { _satinalmaSiparisDetay = value; } }

    }
}
