namespace Notification_System.Services.Observers
{
    public interface INotificationObserver
    {
        Task Update(string recipient, string title, string message);
    }
}
