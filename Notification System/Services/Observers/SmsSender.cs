using Microsoft.Extensions.Configuration;
using NotificationSystem.Services.Interfaces;
using System.Net;
using System.Text.RegularExpressions;
using Vonage;
using Vonage.Messaging;
using Vonage.Request;

namespace NotificationSystem.Services.Senders
{
    public class SmsSender : INotificationSender
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly string _from;

        public SmsSender(IConfiguration configuration)
        {
            _apiKey = configuration["Vonage:ApiKey"] ?? throw new Exception("Vonage API key missing");
            _apiSecret = configuration["Vonage:ApiSecret"] ?? throw new Exception("Vonage API secret missing");
            _from = configuration["Vonage:From"] ?? "MyApp";
        }

        public async Task<bool> SendAsync(string? recipient, string title, string message)
        {
            if (string.IsNullOrWhiteSpace(recipient))
                throw new ArgumentException("Recipient cannot be empty.");

            // South African number validation
            if (!Regex.IsMatch(recipient, @"^\+27\d{9}$"))
                throw new ArgumentException("Invalid South African phone number. Must be in +27XXXXXXXXX format.");

            try
            {
                var credentials = Credentials.FromApiKeyAndSecret(_apiKey, _apiSecret);
                var client = new VonageClient(credentials);

                // Combine title and message
                string smsText = string.IsNullOrWhiteSpace(title) ? message : $"{title}: {message}";

                var response = await client.SmsClient.SendAnSmsAsync(new SendSmsRequest
                {
                    To = recipient,
                    From = _from,
                    Text = smsText
                });

                return response.Messages[0].Status == "0"; // 0 = success
            }
            catch (Exception ex)
            {
                Console.WriteLine("Vonage SMS failed: " + ex.Message);
                return false;
            }
        }
    }
}
