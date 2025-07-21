using Models;
using Models.DTO;

namespace ApiService.Interfaces
{
    public interface ISatinalmaTalepService
    {
        public Task<string> SaveSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik);
        public Task<string> GetSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik=null);
        public Task<string> GetSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay=null);
        public string GetSatinalmaTalepSatirDetay(SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay);
        public Task<string> GetTalepTipleri();
        public Task<string> GetFilteredSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis);
        public Task<string> DeleteSatinalmaTalep(SatinalmaTalep satinalmaTalepBaslik);
        public Task<string> SaveSatinalmaTeklifTalep(List<SatinalmaTalepDetay> satinalmaTalepDetayList);
        public Task<string> GetFilteredSatinalmaTalepDetay(SatinalmaTalepDetay satinalmaTalepDetay);
        public Task<string> SatinalmaTalepOnay(SatinalmaTalep satinalmaTalepBaslik);
    }

}
