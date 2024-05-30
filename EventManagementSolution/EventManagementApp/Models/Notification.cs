using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; } // Foreign Key
        public string Message { get; set; }
        public string? SourceURL { get; set; }
        public DateTime NotificationDate { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
        public User User { get; set; }
    }
}
