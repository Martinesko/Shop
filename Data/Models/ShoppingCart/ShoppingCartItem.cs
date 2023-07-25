using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Data.Models;

namespace Shop.Data.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("ShoppingCard")]  
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
     

        [Required]
        [ForeignKey("Product")]  
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
      

        [Required]
        public int Quanity { get; set; }
    }
}
