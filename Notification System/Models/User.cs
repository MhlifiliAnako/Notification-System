namespace Notification_System.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string FullName { get; set; }
        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? DeviceToken { get; set; }

        public List<UserNotificationPreference> Preferences { get; set; }
            = new List<UserNotificationPreference>();
    }
}
