using Models;

namespace ApiService.Interfaces
{
    public interface ISatinalmaService
    {
        public Task<string> SaveSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik);
        public Task<string> GetSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik);
        public string GetSatinalmaTalepSatirDetay(SatinalmaTalepDetay satinalmaTalepDetay);
        public Task<string> GetTalepTipleri();
        public Task<string> GetFilteredSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis);
        public Task<string> DeleteSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik);
        public Task<string> SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList);
        public Task<string> GetFilteredSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay);
    }

}
