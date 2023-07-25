using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
