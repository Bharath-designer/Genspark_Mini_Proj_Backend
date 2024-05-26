using System.ComponentModel.DataAnnotations;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int OrderId { get; set; } // Foreign Key
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentMethod {  get; set; }
        public Order Order { get; set; }
    }
}
