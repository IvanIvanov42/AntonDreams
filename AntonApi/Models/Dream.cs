using System.ComponentModel.DataAnnotations;

namespace AntonApi.Models
{
    public class Dream
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(15)]
        public required string Text { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
    }
}
