namespace Notification_System.Models
{
    public class UserNotificationPreference
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required string NotificationType { get; set; }

        public User? User { get; set; }
    }
}
