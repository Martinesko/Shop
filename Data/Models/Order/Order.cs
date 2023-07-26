using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("CustomUser")] 
        public Guid UserId { get; set; }
        public CustomUser CustomUser { get; set; } = null!;
        
        [Required]
        public DateTime OrderDate { get; set; }

        [Required] public decimal OrderPrice => ShoppingCart.ShoppingCartItems.Sum(x => x.Product.Price);


        [Required]
        [ForeignKey("ShippingAddress")]
        public Guid ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; } = null!;


        [Required]
        [ForeignKey("OrderStatus")]
        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;
        

        [Required]
        [ForeignKey("ShoppingCart")]
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
        

    }
}
