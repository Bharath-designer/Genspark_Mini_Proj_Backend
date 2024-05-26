using System.ComponentModel.DataAnnotations;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
{
    public class Refund
    {
        [Key]
        public int RefundId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public double RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public RefundStatus RefundStatus { get; set; }
        public Order Order { get; set; }

    }
}
