using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Stok
{
    public class ProfilKesimListesiBaslik
    {
        public int Id { get; set; }
        public ProfilTip profilTip { get; set; }
        public SatinalmaTalepDetay satinalmaTalepDetay { get; set; }
        public ProfilKesimListesiDetay profilKesimListesiDetay { get; set; }
    }
    public class ProfilKesimListesiDetay
    {
        public int Id { get; set; }
        public int kesimSiraNo { get; set; }
        public StokKart stokKart { get; set; }
    }
    public class CuttingOptimizationResult
    {
        public List<List<SatinalmaTalepDetay>> Bins { get; set; }
        public double TotalWaste { get; set; }
        public double UsableWaste { get; set; }
        public double WastePercentage { get; set; }
        public int TotalStocksUsed { get; set; }
    }
    public class BinInfo
    {
        public List<SatinalmaTalepDetay> Pieces { get; set; }
        public double Capacity { get; set; }
        public double UsedSpace { get; set; }
        public double RemainingSpace => Capacity - UsedSpace;

        public BinInfo(double capacity)
        {
            Capacity = capacity;
            UsedSpace = 0;
            Pieces = new List<SatinalmaTalepDetay>();
        }

        public void AddPiece(SatinalmaTalepDetay piece, int kerf)
        {
            double kerfSpace = Pieces.Count > 0 ? kerf : 0;
            UsedSpace += piece.projeStokKart.stokKart.uzunluk.Value + kerfSpace;
            Pieces.Add(piece);
        }
    }
}
