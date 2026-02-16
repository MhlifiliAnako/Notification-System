using Notification_System.Services.Observers;
using System.Collections.Generic;

namespace NotificationSystem.Services.Observers
{
    public class NotificationSubject
    {
        private List<INotificationObserver> _observers = new();

        public void Attach(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public async Task Notify(string recipient, string title, string message)
        {
            foreach (var observer in _observers)
            {
                await observer.Update(recipient, title, message);
            }
        }
    }
}
