using System.ComponentModel.DataAnnotations;

namespace AntonDream.Models
{
    public class Dream
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Write it downnnn")]
        [MinLength(15, ErrorMessage = "Don't be lazy! More!")]
        public string? Text { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
    }
}
