using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.Configuration;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHashingOptions _options;
        private readonly ILogger<PasswordService> _logger;

        public PasswordService(IOptions<PasswordHashingOptions> options, ILogger<PasswordService> logger = null)
        {
            _options = options?.Value ?? new PasswordHashingOptions();
            _logger = logger;
        }

        /// <summary>
        /// Güvenli password hashing (PBKDF2 with SHA256)
        /// </summary>
        /// <param name="password">Hash edilecek password</param>
        /// <returns>Password hash result</returns>
        /// <exception cref="ArgumentException">Geçersiz password durumunda</exception>
        public PasswordHashResult HashPassword(string password)
        {
            var validation = ValidatePassword(password);
            if (!validation.IsValid)
            {
                throw new ArgumentException($"Invalid password: {string.Join(", ", validation.Errors)}");
            }

            try
            {
                var salt = GenerateCryptographicSalt();
                var hash = ComputeHash(password, salt, _options.Iterations);

                var result = new PasswordHashResult
                {
                    Hash = Convert.ToBase64String(hash),
                    Salt = Convert.ToBase64String(salt),
                    Iterations = _options.Iterations,
                    CreatedAt = DateTime.UtcNow
                };

                _logger?.LogDebug("Password hashed successfully with {Iterations} iterations", _options.Iterations);
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to hash password");
                throw new InvalidOperationException("Failed to hash password", ex);
            }
        }

        /// <summary>
        /// Combined hash format ile password doğrulama
        /// </summary>
        /// <param name="password">Doğrulanacak password</param>
        /// <param name="storedHash">Stored combined hash (iterations$salt$hash)</param>
        /// <returns>Doğrulama sonucu</returns>
        public bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedHash))
            {
                return false;
            }

            try
            {
                var parts = storedHash.Split('$');
                if (parts.Length != 3)
                {
                    _logger?.LogWarning("Invalid stored hash format");
                    return false;
                }

                if (!int.TryParse(parts[0], out int iterations))
                {
                    _logger?.LogWarning("Invalid iterations in stored hash");
                    return false;
                }

                return VerifyPassword(password, parts[2], parts[1], iterations);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error during password verification");
                return false;
            }
        }

        /// <summary>
        /// Ayrı parametreler ile password doğrulama
        /// </summary>
        /// <param name="password">Doğrulanacak password</param>
        /// <param name="hash">Stored hash</param>
        /// <param name="salt">Stored salt</param>
        /// <param name="iterations">Hash iterations</param>
        /// <returns>Doğrulama sonucu</returns>
        public bool VerifyPassword(string password, string hash, string salt, int iterations)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash) || string.IsNullOrWhiteSpace(salt))
            {
                return false;
            }

            try
            {
                var saltBytes = Convert.FromBase64String(salt);
                var hashBytes = Convert.FromBase64String(hash);
                var computedHash = ComputeHash(password, saltBytes, iterations);

                // Timing attack'a karşı constant-time comparison
                return CryptographicOperations.FixedTimeEquals(hashBytes, computedHash);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error during password verification with separate parameters");
                return false;
            }
        }

        /// <summary>
        /// Password güçlülük ve format validasyonu
        /// </summary>
        /// <param name="password">Validate edilecek password</param>
        /// <returns>Validation result</returns>
        public PasswordValidationResult ValidatePassword(string password)
        {
            var result = new PasswordValidationResult();

            if (string.IsNullOrEmpty(password))
            {
                result.Errors.Add("Password cannot be empty");
                result.Strength = PasswordStrength.VeryWeak;
                return result;
            }

            // Length validation
            if (password.Length < _options.MinPasswordLength)
            {
                result.Errors.Add($"Password must be at least {_options.MinPasswordLength} characters long");
            }

            if (password.Length > _options.MaxPasswordLength)
            {
                result.Errors.Add($"Password cannot exceed {_options.MaxPasswordLength} characters");
            }

            // Character variety validation
            var hasLower = password.Any(char.IsLower);
            var hasUpper = password.Any(char.IsUpper);
            var hasDigit = password.Any(char.IsDigit);
            var hasSpecial = password.Any(c => !char.IsLetterOrDigit(c));

            if (!hasLower) result.Errors.Add("Password must contain at least one lowercase letter");
            if (!hasUpper) result.Errors.Add("Password must contain at least one uppercase letter");
            if (!hasDigit) result.Errors.Add("Password must contain at least one digit");
            if (!hasSpecial) result.Errors.Add("Password must contain at least one special character");

            // Common password checks
            if (IsCommonPassword(password))
            {
                result.Errors.Add("Password is too common and easily guessable");
            }

            result.IsValid = result.Errors.Count == 0;
            result.Strength = CalculatePasswordStrength(password);

            return result;
        }

        /// <summary>
        /// Password güçlülük hesaplama
        /// </summary>
        /// <param name="password">Analiz edilecek password</param>
        /// <returns>Password strength</returns>
        public PasswordStrength CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return PasswordStrength.VeryWeak;

            int score = 0;

            // Length scoring
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            // Character variety scoring
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(c => !char.IsLetterOrDigit(c))) score++;

            // Pattern analysis
            if (!HasRepeatingPatterns(password)) score++;
            if (!IsCommonPassword(password)) score++;

            return score switch
            {
                <= 2 => PasswordStrength.VeryWeak,
                3 => PasswordStrength.Weak,
                4 => PasswordStrength.Fair,
                5 => PasswordStrength.Good,
                >= 6 => PasswordStrength.Strong
            };
        }

        /// <summary>
        /// Güvenli random password oluşturma
        /// </summary>
        /// <param name="length">Password uzunluğu</param>
        /// <returns>Generated password</returns>
        public string GenerateSecureRandomPassword(int length = 16)
        {
            if (length < 8)
                throw new ArgumentException("Password length must be at least 8 characters");

            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            var allChars = lowercase + uppercase + digits + special;
            var password = new StringBuilder();

            using var rng = RandomNumberGenerator.Create();

            // Ensure at least one character from each category
            password.Append(GetRandomChar(lowercase, rng));
            password.Append(GetRandomChar(uppercase, rng));
            password.Append(GetRandomChar(digits, rng));
            password.Append(GetRandomChar(special, rng));

            // Fill the rest randomly
            for (int i = 4; i < length; i++)
            {
                password.Append(GetRandomChar(allChars, rng));
            }

            // Shuffle the password
            return ShuffleString(password.ToString(), rng);
        }

        /// <summary>
        /// Check if password is in common/breached password list
        /// </summary>
        /// <param name="password">Password to check</param>
        /// <returns>True if compromised</returns>
        public bool IsPasswordCompromised(string password)
        {
            // Future implementation: Check against HaveIBeenPwned API or local breach database
            // For now, just check against very common passwords
            return IsCommonPassword(password);
        }

        #region Private Helper Methods

        /// <summary>
        /// PBKDF2 ile güvenli hash hesaplama
        /// </summary>
        private byte[] ComputeHash(string password, byte[] salt, int iterations)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(_options.HashSize);
        }

        /// <summary>
        /// Kriptografik olarak güvenli salt oluşturma
        /// </summary>
        private byte[] GenerateCryptographicSalt()
        {
            var salt = new byte[_options.SaltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }

        private static char GetRandomChar(string chars, RandomNumberGenerator rng)
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            var randomIndex = Math.Abs(BitConverter.ToInt32(bytes, 0)) % chars.Length;
            return chars[randomIndex];
        }

        private static string ShuffleString(string input, RandomNumberGenerator rng)
        {
            var array = input.ToCharArray();
            for (int i = array.Length - 1; i > 0; i--)
            {
                var bytes = new byte[4];
                rng.GetBytes(bytes);
                var randomIndex = Math.Abs(BitConverter.ToInt32(bytes, 0)) % (i + 1);
                (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
            }
            return new string(array);
        }

        private static bool HasRepeatingPatterns(string password)
        {
            // Simple pattern detection (consecutive characters, repeated sequences)
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i + 1] == password[i + 2])
                    return true; // Three consecutive same characters
            }
            return false;
        }

        private static bool IsCommonPassword(string password)
        {
            var commonPasswords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "password", "123456", "123456789", "qwerty", "abc123", "111111",
            "password123", "admin", "letmein", "welcome", "monkey", "dragon",
            "master", "sunshine", "princess", "football", "baseball", "shadow"
        };

            return commonPasswords.Contains(password);
        }

        #endregion
    }

}
