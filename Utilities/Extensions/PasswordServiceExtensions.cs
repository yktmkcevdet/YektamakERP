using Models.Models;
using Utilities.Interfaces;

namespace Utilities.Extensions
{
    public static class PasswordServiceExtensions
    {
        /// <summary>
        /// Password'u hash'leyip combined format'ta döndürür
        /// </summary>
        public static string ToSecureHash(this string password, IPasswordService passwordService)
        {
            var result = passwordService.HashPassword(password);
            return result.CombinedHash;
        }

        /// <summary>
        /// Password güçlülüğünü string olarak döndürür
        /// </summary>
        public static string GetStrengthDescription(this PasswordStrength strength)
        {
            return strength switch
            {
                PasswordStrength.VeryWeak => "Very Weak - Unacceptable",
                PasswordStrength.Weak => "Weak - Poor security",
                PasswordStrength.Fair => "Fair - Acceptable but improvable",
                PasswordStrength.Good => "Good - Solid security",
                PasswordStrength.Strong => "Strong - Excellent security",
                _ => "Unknown"
            };
        }
    }
}
