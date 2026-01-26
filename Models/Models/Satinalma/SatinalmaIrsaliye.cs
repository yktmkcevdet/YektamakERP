using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Satinalma
{
    public class SatinalmaIrsaliye:IEntity
    {
        public int? Id { get; set; }
        public string irsaliyeNo { get; set; }
        public DateTime? irsaliyeTarih { get; set; }
        public Firma firma { get; set; }
        public string aciklama { get; set; }
        public List<SatinalmaIrsaliyeDetay> satinalmaIrsaliyeDetayList { get; set; }
    }
    public class SatinalmaIrsaliyeDetay:IEntity
    {
        public int? Id { get; set; }
        public SatinalmaIrsaliye satinalmaIrsaliye { get; set; }
        public StokKart stokKart { get; set; }
        public double? miktar { get; set; }
        public string birim { get; set; }
        public double? birimFiyat { get; set; }
        public double? kdvOran { get; set; }
        public double? toplamTutar { get; set; }
    }
}
