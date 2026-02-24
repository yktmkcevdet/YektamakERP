using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    public interface IMailService
    {
        public void SendSystemMail(string to, string cc, string subject, string body, List<MailAttachament> attachmentData = null);
        public void SendUserMail(Kullanici kullanici, string to, string subject, string body, List<MailAttachament> attachmentData = null);
        public Task SendMailGraph(string to, string cc, string subject, string body, List<MailAttachament> attachmentData = null);
    }
}
