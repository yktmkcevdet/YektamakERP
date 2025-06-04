namespace Utilities.Interfaces
{
    public interface ILoginHelper
    {
        public string ComputeHash(string password, string salt);
        public string GenerateCryptographicSalt();
    }
}
