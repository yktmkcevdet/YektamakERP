using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SatinalmaTalepSatirDetayDTO:IEntity
    {
        [GridDisplay(Header ="Id",Visible = true)]
        public int? Id { get; set; }
        [GridDisplay(Header = "Stok Kart Id", Visible = true)]
        public int? stokKartId { get; set; }
        [GridDisplay(Header = "Stok Kart Kodu", Visible = true)]
        public string stokKartkod { get; set; }
        [GridDisplay(Header = "Stok Kart Adı", Visible = true)]
        public string stokKartad { get; set; }
        [GridDisplay(Header = "Miktar", Visible = true)]
        public double? miktar { get; set; }
        [GridDisplay(Header = "Ağırlık", Visible = true)]
        public double? stokKartagirlik { get; set; }
    }
}
