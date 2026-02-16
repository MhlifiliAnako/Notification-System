using NotificationSystem.Services.Interfaces;
using NotificationSystem.Services.Senders;

namespace Notification_System.Services
{
    public class NotificationService
    {
        private readonly SmsSender _smsSender;
        private readonly EmailSender _emailSender;

        public NotificationService(SmsSender smsSender, EmailSender emailSender)
        {
            _smsSender = smsSender;
            _emailSender = emailSender;
        }

        public async Task<bool> SendNotification(string recipient, string title, string message, string type)
        {
            return type switch
            {
                "SMS" => await _smsSender.SendAsync(recipient, title, message),
                "Email" => await _emailSender.SendAsync(recipient, title, message),
                _ => false
            };
        }
    }

}
