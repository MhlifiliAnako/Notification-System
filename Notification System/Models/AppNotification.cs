namespace Notification_System.Models
{
    public class AppNotification
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public required string Title { get; set; }
        public required string Message { get; set; }
        public required string NotificationType { get; set; }
        public required string Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? SentDate { get; set; }

        public User? User { get; set; }

    }
}
