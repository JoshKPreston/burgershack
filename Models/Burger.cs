using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class Burger
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsBacon { get; set; }
        
    }
}