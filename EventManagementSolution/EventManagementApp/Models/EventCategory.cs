﻿using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Models
{
    public class EventCategory
    {
        [Key]
        public int EventCategoryId {  get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<QuotationRequest> QuotationRequests { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ScheduledEvent> ScheduledEvents { get; set; }
    }
}