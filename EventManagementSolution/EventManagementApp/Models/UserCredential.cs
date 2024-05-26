using System.ComponentModel.DataAnnotations;
using EventManagementApp.Enums;

namespace EventManagementApp.Models
{
    public class UserCredential
    {
        [Key]
        public int UserCredentialId {  get; set; }
        public int UserId { get; set; } // Foreign Key
        public byte[] HashedPassword { get; set; }
        public byte[] HaskKey { get; set; }
        public UserType Role { get; set; }
        public User User { get; set; }
    }
}