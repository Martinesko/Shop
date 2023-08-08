using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Data.Models.Products;

namespace Shop.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make Make { get; set; } = null!;

        [Required] 
        public string Model { get; set; } = null!; 

        [Required]
        [ForeignKey("ModelType")] 
        public int ModelTypeId { get; set; }
        public ModelType ModelType { get; set; } = null!;

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
       
        public string? Description { get; set; }

        public ICollection<ImageUrlProduct> ImageUrls { get; set; } = new HashSet<ImageUrlProduct>();

        
        [ForeignKey("Color")] 
        public int? ColorId { get; set; }
        public Color Color { get; set; } = null!;
        
        
        
    }
}
