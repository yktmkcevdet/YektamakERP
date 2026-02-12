using Models;

namespace ApiService.Interfaces
{
    public interface ISatinalmaIrsaliyeService
    {
        public Task<List<SatinalmaIrsaliyeBaslik>> SaveSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik);
        public Task<List<SatinalmaIrsaliyeBaslik>> GetSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik);
        public Task<string> DeleteSatinalmaIrsaliye(SatinalmaIrsaliyeBaslik satinalmaIrsaliyeBaslik);
    }
}
