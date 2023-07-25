using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class ImageUrlProduct
    {
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        [ForeignKey("ImageUrl")]
        public int ImageUrlId { get; set; }
        public ImageUrl ImageUrl { get; set; } = null!;
    }
}
