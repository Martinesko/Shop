using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string City { get; set; } = null!;

        [Required] 
        public string Street1 { get; set; } = null!;
        public string? Street2 { get; set;}
        
        [Required]
        public string StreetNumber { get; set; } = null!;
        [Required]
        public string PostCode { get; set; } = null!;

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        

    }
}
