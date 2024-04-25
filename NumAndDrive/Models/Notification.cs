namespace NumAndDrive.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<UserNotification> UserNotifications { get; set; } = [];
    }
}
