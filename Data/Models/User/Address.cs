﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shop.Common.EntityValidationConstants.Adress;

namespace Shop.Data.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(StreetMaxLength, MinimumLength = StreetMinLength)]
        public string Street1 { get; set; } = null!;

        [StringLength(StreetMaxLength, MinimumLength = StreetMinLength)]
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
