using System.ComponentModel.DataAnnotations;

namespace AntonDream.Models
{
    public class Dream
    {
        public long Id { get; set; }
        [Required]
        [MinLength(25)]
        public required string Text { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
    }
}
