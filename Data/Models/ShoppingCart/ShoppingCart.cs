using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("CustomUser")]
        public Guid UserId { get; set; }
        public CustomUser CustomUser { get; set; } = null!;

        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    }
}
