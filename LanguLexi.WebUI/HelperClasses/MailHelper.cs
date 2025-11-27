using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using LanguLexi.Core.Entities;

namespace LanguLexi.WebUI.HelperClasses
{
    public class MailHelper
    {
        public static async Task<bool> SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail@siteadi.com", 587);
            smtpClient.Credentials = new NetworkCredential("info@siteadi.com", "mailşifresi");
            smtpClient.EnableSsl = false;
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("info@siteadi.com");
            emailMessage.To.Add("bilgi@siteadi.com");
            emailMessage.Subject = "Siteden mesaj geldi";
            emailMessage.Body = $"İsim:{contact.FirstName} Soyisim:{contact.LastName} Telefon:{contact.Phone} E-Mail:{contact.EMailAddress} Mesaj:{contact.ContactMessage}";
            emailMessage.IsBodyHtml = true;

            try
            {
                await smtpClient.SendMailAsync(emailMessage);
                smtpClient.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        
     
        public static async Task<bool> SendMailAsync(string emailAddress,string emailSubject,string emailBody)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com",587);
            smtpClient.Credentials = new NetworkCredential("info@siteadi.com", "mailşifresi");
            smtpClient.EnableSsl = false;
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("info@siteadi.com");
            emailMessage.To.Add(emailAddress);
            emailMessage.Subject = emailSubject;
            emailMessage.Body = emailBody;
            emailMessage.IsBodyHtml = true;

            try
            {
                await smtpClient.SendMailAsync(emailMessage);
                smtpClient.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
