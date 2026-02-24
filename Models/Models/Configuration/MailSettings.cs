using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Configuration
{
    public class MailSettings
    {
        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string tenantId { get; set; }
        public string clientId { get; set; }
        public string clientSecret { get; set; }
    }
}
