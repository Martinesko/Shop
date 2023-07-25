using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")] 
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        
        [Required]
        public DateTime OrderDate { get; set; }

        [Required] public decimal OrderPrice => ShoppingCart.ShoppingCartItems.Sum(x => x.Product.Price);

        [Required]
        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;
        

        [Required]
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
        

    }
}
