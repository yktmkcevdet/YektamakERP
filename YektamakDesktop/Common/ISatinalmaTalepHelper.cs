using Models;
using Models.DTO;
using Models.Models.Stok;
using System.Collections.Generic;

namespace YektamakDesktop.Common
{
    public interface ISatinalmaTalepHelper
    {
        void CreateSatinalmaTalep(List<ProjeStokKartDTO> talepList, Proje proje, MalzemeGrup malzemeGrup);
        void CreateSatinalmaTalep(List<SatinalmaTalepDetay> talepList, Proje proje, MalzemeGrup malzemeGrup);
        CuttingOptimizationResult OptimizedCutting(List<ProjeStokKartDTO> items, double stockLength, int kerf, double usableWasteMinLength = 0);
    }
}