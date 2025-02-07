namespace Utilities.Interfaces
{
    public interface ILoginHelper
    {
        public string HashPassword(string password, string salt);
        public string GenerateSalt();
    }
}
