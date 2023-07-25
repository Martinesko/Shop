using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class OrderStatus
    {
        [Key]
        public Guid Id { get; set; }

        [Required] public string Status { get; set; } = null!;
    }
}
