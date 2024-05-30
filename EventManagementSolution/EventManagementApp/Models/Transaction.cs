using System.ComponentModel.DataAnnotations;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public string PaymentURL { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public PaymentStatus PaymentStatus { get; set; }
        public string? PaymentMethod {  get; set; }
        public Order Order { get; set; }
        public Refund Refund { get; set; }
    }
}
