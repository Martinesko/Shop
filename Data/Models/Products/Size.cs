using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models.Products
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
