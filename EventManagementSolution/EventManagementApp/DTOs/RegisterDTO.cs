using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
