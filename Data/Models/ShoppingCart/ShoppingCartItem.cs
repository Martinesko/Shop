using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Data.Models.Products;

namespace Shop.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ShoppingCard")]  
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
     

        [Required]
        [ForeignKey("Product")]  
        public string ProductId { get; set; }
        public Product Product { get; set; } = null!;
      

        [Required]
        public string Quanity { get; set; }
    }
}
