using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class ImageUrl
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; } = null!;

    }
}
