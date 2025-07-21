using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PasswordHashResult
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int Iterations { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Combined format: iterations$salt$hash
        /// </summary>
        public string CombinedHash => $"{Iterations}${Salt}${Hash}";
    }
}
