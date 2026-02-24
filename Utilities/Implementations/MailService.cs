using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Models;
using Models.Models.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementations
{
    public class MailService:IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public void SendSystemMail(string to, string cc, string subject, string body, List<MailAttachament> attachmentData = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string senderEmail = _mailSettings.From;
                string senderPassword = _mailSettings.Password;
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(to);
                if (!string.IsNullOrEmpty(cc)) mail.CC.Add(cc);
                mail.Subject = subject;
                mail.Body = body;
                mail.Bcc.Add("cevdet.oguz@yektamak.com.tr");
                mail.IsBodyHtml = true;
                // Mail gönderimi tamamlanana kadar stream'leri tut
                List<MemoryStream> streamsToDispose = new List<MemoryStream>();

                if (attachmentData != null)
                {
                    foreach (var attachment in attachmentData)
                    {
                        MemoryStream ms = new MemoryStream(attachment.fileData);
                        streamsToDispose.Add(ms); // sonra temizlenecek
                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, attachment.fileName);
                        mail.Attachments.Add(attach);
                    }
                }

                SmtpClient smtpClient = new SmtpClient(_mailSettings.Host)
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                    Port = _mailSettings.Port
                };

                smtpClient.Send(mail);

                // Gönderimden sonra stream'leri kapat
                foreach (var stream in streamsToDispose)
                    stream.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Mail gönderim hatası: " + ex.Message);
            }
        }
        public void SendUserMail(Kullanici kullanici, string to, string subject, string body, List<MailAttachament> attachmentData = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string senderEmail = kullanici.mailAdres.adres;
                string senderPassword = kullanici.mailAdres.sifre;
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.Bcc.Add("cevdet.oguz@yektamak.com.tr");
                mail.IsBodyHtml = true;
                // Mail gönderimi tamamlanana kadar stream'leri tut
                List<MemoryStream> streamsToDispose = new List<MemoryStream>();

                if (attachmentData != null)
                {
                    foreach (var attachment in attachmentData)
                    {
                        MemoryStream ms = new MemoryStream(attachment.fileData);
                        streamsToDispose.Add(ms); // sonra temizlenecek
                        System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, attachment.fileName);
                        mail.Attachments.Add(attach);
                    }
                }

                SmtpClient smtpClient = new SmtpClient(kullanici.mailAdres.smtpServer)
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = kullanici.mailAdres.SSL,
                    Port = kullanici.mailAdres.port
                };

                smtpClient.Send(mail);

                // Gönderimden sonra stream'leri kapat
                foreach (var stream in streamsToDispose)
                    stream.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Mail gönderim hatası: " + ex.Message);
            }
        }

        public async Task SendMailGraph(string to, string cc, string subject, string body, List<MailAttachament> attachmentData = null)
        {
            var test = Environment.GetEnvironmentVariable("MailSettings__Password");

            var credential = new ClientSecretCredential(
                _mailSettings.tenantId, _mailSettings.clientId, _mailSettings.clientSecret);

            var graphClient = new GraphServiceClient(credential);

            var message = new Microsoft.Graph.Models.Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Html,
                    Content = body
                },
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = to
                        }
                    }
                }
            };
            try
            {
                await graphClient.Users[_mailSettings.From]
                .SendMail
                .PostAsync(new Microsoft.Graph.Users.Item.SendMail.SendMailPostRequestBody
                {
                    Message = message
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
