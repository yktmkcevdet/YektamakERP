using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace YektamakDesktop.Helpers
{
    public static class MailHelper
    {
        public static void SendSystemMail(string to,string cc, string subject, string body, List<MailAttachament> attachmentData = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string senderEmail = "noreply@yektamak.com.tr";
                string senderPassword = "Yod43257";
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(to);
                mail.CC.Add(cc);
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
                        Attachment attach = new Attachment(ms, attachment.fileName);
                        mail.Attachments.Add(attach);
                    }
                }

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                    Port = 587
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
        public static void SendUserMail(Kullanici kullanici, string to, string subject, string body, List<MailAttachament> attachmentData = null)
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
                        Attachment attach = new Attachment(ms, attachment.fileName);
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
    }
}
