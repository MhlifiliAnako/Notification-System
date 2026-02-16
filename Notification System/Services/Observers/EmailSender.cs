using NotificationSystem.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace NotificationSystem.Services.Senders
{
    public class EmailSender : INotificationSender
    {
        public async Task<bool> SendAsync(string? recipient, string title, string message)
        {
            if (string.IsNullOrEmpty(recipient))
                return false;

            try
            {
                // Use your Gmail App Password or SMTP server
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("mhlifilianako@gmail.com", "dobttogezciwnkvp"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("mhlifilianako@gmail.com"),
                    Subject = title,
                    Body = message,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(recipient);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
