using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Configuration;
using Notification_System.Models;
using NotificationSystem.Services.Interfaces;


namespace NotificationSystem.Services.Senders
{
    public class PushSender : INotificationSender
    {
        private readonly FirebaseApp _firebaseApp;

        public PushSender(IConfiguration configuration)
        {
            var credentialsPath = configuration["Firebase:CredentialsPath"];
            if (string.IsNullOrWhiteSpace(credentialsPath))
                throw new Exception("Firebase credentials path missing in configuration.");

            _firebaseApp = FirebaseApp.DefaultInstance ?? FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(credentialsPath)
            });
        }

        public async Task<bool> SendAsync(string? recipientToken, string title, string message)
        {
            if (string.IsNullOrWhiteSpace(recipientToken))
                throw new ArgumentException("Recipient token cannot be empty.");

            try
            {
                var msg = new Message()
                {
                    Token = recipientToken,
                    Notification = new Notification
                    {
                        Title = title,
                        Body = message
                    }
                };

                var result = await FirebaseMessaging.DefaultInstance.SendAsync(msg);
                Console.WriteLine("Push notification sent: " + result);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Push notification failed: " + ex.Message);
                return false;
            }
        }
    }
}
