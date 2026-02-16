namespace NotificationSystem.Services.Interfaces
{
    public interface INotificationSender
    {
        Task<bool> SendAsync(string? recipient, string title, string message);
    }
}
