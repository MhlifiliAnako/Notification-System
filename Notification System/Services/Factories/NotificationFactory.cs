using NotificationSystem.Services.Interfaces;
using NotificationSystem.Services.Senders;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

public class NotificationFactory
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public INotificationSender Create(string type)
    {
        return type switch
        {
            "Email" => _serviceProvider.GetRequiredService<EmailSender>(),
            "SMS" => _serviceProvider.GetRequiredService<SmsSender>(),
            "Push" => _serviceProvider.GetRequiredService<PushSender>(),
            _ => throw new ArgumentException("Invalid type")
        };
    }

}
