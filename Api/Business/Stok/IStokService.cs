using Models;

namespace Api.Business
{
    public interface IStokService
    {
        public Task<string> SaveStokKartDosya(StokKartDosya stokKartDosya);
    }
}
