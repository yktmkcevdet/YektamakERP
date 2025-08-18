using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public record ProjeDTO:IEntity
    {
        [GridDisplay(Header ="Id")]
        public int? Id { get; set; }
        [GridDisplay(Header ="Kod")]
        public string kod { get; set; }
        [GridDisplay(Header ="Proje No")]
        public int? projeNo { get; set; }
        [GridDisplay(Header = "Ver.", Tip = "TextBox")]
        public string versiyon { get; set; }
        [GridDisplay(Header = "Ad")]
        public string ad { get; set; }
        [GridDisplay(Header = "Proje Tipi",  Tip = "Liste", ListName ="projeTipList",ListVisibleColumnName ="ad")]
        public int? projeTipId { get; set; }
        [GridDisplay(Header = "Marka",  Tip = "Liste", ListName ="markaList",ListVisibleColumnName ="ad")]
        public int? markaId { get; set; }
    }
}
