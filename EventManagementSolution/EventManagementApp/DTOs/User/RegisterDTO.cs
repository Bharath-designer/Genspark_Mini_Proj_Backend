using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.DTOs.User
{
    public class RegisterDTO : LoginDTO
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}
