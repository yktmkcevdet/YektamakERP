using Models;

namespace ApiService.Interfaces
{
    public interface ISatinalmaSiparisService
    {
        public Task<List<SatinalmaSiparis>> GetSatinalmaSiparisAsync(SatinalmaSiparis satinalmaSiparis);
        public Task<List<SatinalmaSiparisDetay>> GetSatinalmaSiparisDetayAsync(SatinalmaSiparisDetay satinalmaSiparisDetay);
        public Task<string> SaveSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis);
        public Task<string> DeleteSatinalmaSiparis(SatinalmaSiparis satinalmaSiparis);
    }
}
