using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configuration
{
    public class PasswordHashingOptions
    {
        public int Iterations { get; set; } = 100000; // PBKDF2 iterations (minimum 100k recommended)
        public int SaltSize { get; set; } = 32; // 32 bytes = 256 bits
        public int HashSize { get; set; } = 32; // 32 bytes = 256 bits
        public int MinPasswordLength { get; set; } = 1;
        public int MaxPasswordLength { get; set; } = 128;
    }
}
