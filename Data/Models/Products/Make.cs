using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models.Products
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
