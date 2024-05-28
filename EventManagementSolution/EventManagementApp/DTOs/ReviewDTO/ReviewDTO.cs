using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.DTOs.ReviewDTO
{
    public class ReviewDTO
    {
        [Required]
        [Range(1,10, ErrorMessage = "Rating should be in between 0 - 10")]
        public float Rating { get; set; }
        public string Comments { get; set; }
    }
}
