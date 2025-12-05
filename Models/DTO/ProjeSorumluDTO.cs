using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ProjeSorumluDTO : IEntity
    {
        [GridDisplay(Header = "Id")] public int? Id { get; set; }
        [GridDisplay(Header = "Proje",Tip ="Liste",ListName ="projeList", ListVisibleColumnName ="kod")] public int? projeId { get; set; }
        [GridDisplay(Header = "Proje Sorumlusu",Tip ="Liste",ListName = "personelList", ListVisibleColumnName ="adSoyad")] public int? personelId { get; set; }
    }
}
