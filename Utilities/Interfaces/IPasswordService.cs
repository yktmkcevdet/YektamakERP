using Models.Models;

namespace Utilities.Interfaces
{
    public interface IPasswordService
    {
        PasswordHashResult HashPassword(string password);
        bool VerifyPassword(string password, string storedHash);
        bool VerifyPassword(string password, string hash, string salt, int iterations);
        PasswordValidationResult ValidatePassword(string password);
        PasswordStrength CalculatePasswordStrength(string password);
        string GenerateSecureRandomPassword(int length = 16);
        bool IsPasswordCompromised(string password); // Future: Check against known breached passwords
    }
}
