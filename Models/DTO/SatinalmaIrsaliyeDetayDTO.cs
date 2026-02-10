using Models.Attributes;

namespace Models.DTO
{
    public class SatinalmaIrsaliyeDetayDTO:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Başlık Id")] public int? satinalmaIrsaliyeBaslikId { get; set; }
        [GridDisplay(Header = "Sipariş Detay Id")] public int? satinalmaSiparisDetayId { get; set; }
        [GridDisplay(Header = "Sipariş Miktar")] public double? satinalmaSiparisDetayMiktar { get; set; }
        [GridDisplay(Header = "Proje StokKart Id")] public int? projeStokKartId { get; set; }
        [GridDisplay(Header = "Stok Kodu")] public string projeStokKartstokKartkod { get; set; }
        [GridDisplay(Header = "Stok Adı")] public string projeStokKartstokKartad { get; set; }
        [GridDisplay(Header = "Giriş Miktar",readOnly =false)] public double? miktar { get; set; }
        [GridDisplay(Header = "Ölçü Birimi",Tip="Liste",ListName ="olcuBirims",ListVisibleColumnName ="kod")]public int? satinalmaSiparisprojeStokKartstokKartolcuBrimId { get; set; }
    }
}   
