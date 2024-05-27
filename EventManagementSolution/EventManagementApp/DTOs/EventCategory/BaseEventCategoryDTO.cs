namespace EventManagementApp.DTOs.EventCategory
{
    public class BaseEventCategoryDTO
    {
        public int EventCategoryId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
