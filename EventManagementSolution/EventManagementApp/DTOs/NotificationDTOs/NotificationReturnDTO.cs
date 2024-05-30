namespace EventManagementApp.DTOs.NotificationDTOs
{
    public class NotificationReturnDTO
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public string? SourceURL { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
