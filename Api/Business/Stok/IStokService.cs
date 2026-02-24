using Models;
using System.Data;

namespace Api.Business
{
    public interface IStokService
    {
        public Task<string> SaveStokKartDosya(StokKartDosya stokKartDosya, IDbConnection dbConnection, IDbTransaction dbTransaction);
        public Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart, IDbConnection dbConnection, IDbTransaction dbTransaction);
    }
}
