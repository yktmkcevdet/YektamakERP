using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Models
{
    public class CariHareketler
    {
        public DateTime FaturaTarihi { get; set; }
        public DateTime VadeTarihi { get; set; }
        public string FisDurumu { get; set; }
        public string Aciklama { get; set; }
        public double BorcTutari { get; set; }
        public double AlacakTutari { get; set; }
    }
    public class ListCariHareketler
    {
        public List<CariHareketler> cariHareketlers { get; set; }
    }
}
