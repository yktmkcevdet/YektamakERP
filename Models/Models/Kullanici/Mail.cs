using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MailAdres:IEntity
    {
        [GridDisplay(Header ="Id")]public int? Id { get; set; }
        [GridDisplay(Header = "Mail Adresi")] public string adres { get; set; }
        [GridDisplay(Header = "Mail Şifresi")] public string sifre { get; set; }
        [GridDisplay(Header = "SMTP Server")] public string smtpServer { get; set; }
        [GridDisplay(Header = "Port")] public int port { get; set; }
        [GridDisplay(Header = "SSL")] public bool SSL { get; set; }
    }
}
