using System.ComponentModel.DataAnnotations;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
{
    public class Refund
    {
        [Key]
        public int RefundId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public string TransactionId { get; set; } // Foreign Key
        public double RefundAmount { get; set; }
        public Currency Currency { get; set; }
        public DateTime RefundDate { get; set; } = DateTime.Now;
        public string Reason { get; set; }
        public RefundStatus RefundStatus { get; set; } = RefundStatus.Initiated;
        public Order Order { get; set; }
        public Transaction Transaction { get; set; }

    }
}
