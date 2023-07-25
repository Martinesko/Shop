using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required] public string Make { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;

        [Required]
        [ForeignKey("ModelType")] 
        public int ModelTypeId { get; set; }
        public ModelType ModelType { get; set; } = null!;

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null;

        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; } = null!;

        public ICollection<ImageUrlProduct> ImageUrls { get; set; } = new HashSet<ImageUrlProduct>();

        [Required]
        [ForeignKey("Color")] 
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
        
        
        
    }
}
