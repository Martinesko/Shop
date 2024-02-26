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

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Make is required")]
        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make Make { get; set; } = null!;

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Model type is required")]
        [ForeignKey("ModelType")]
        public int ModelTypeId { get; set; }
        public ModelType ModelType { get; set; } = null!;

        [Required(ErrorMessage = "Category is required")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required(ErrorMessage = "Size is required")]
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}