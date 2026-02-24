using Models.Attributes;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaIrsaliyeBaslikDTO:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "İrsaliye No")] public string irsaliyeNo { get; set; }
        [GridDisplay(Header = "Tarih")] public DateTime? tarih { get; set; }
        [GridDisplay(Header = "Proje Kod", Tip ="Liste", ListName ="projeList",ListVisibleColumnName ="kod")] public int? projeId { get; set; }
        [GridDisplay(Header = "Firma", Tip = "Liste", ListName = "firmaList", ListVisibleColumnName = "ad")] public int? firmaId { get; set; }
        [GridDisplay(Header = "Stok Grup", Tip = "Liste", ListName = "stokGrups", ListVisibleColumnName = "ad")] public int? stokGrupId { get; set; }
        [GridDisplay(Header = "Malzeme Grup", Tip = "Liste", ListName = "malzemeGrups", ListVisibleColumnName = "ad")] public int? malzemeGrupId { get; set; }
        [GridDisplay(Header = "Açıklama")] public string aciklama { get; set; }
        [GridDisplay(Header = "Detay")] public List<SatinalmaIrsaliyeDetay> satinalmaIrsaliyeDetayList { get; set; }
    }
}
