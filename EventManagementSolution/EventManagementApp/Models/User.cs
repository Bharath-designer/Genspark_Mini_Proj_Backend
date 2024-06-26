﻿using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public UserCredential UserCredential { get; set; }
        public List<QuotationRequest> QuotationRequests { get; set; }
        public List<ScheduledEvent> ScheduledEvents { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Notification> Notifications { get; set; }
    }

}
