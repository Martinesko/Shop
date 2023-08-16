using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shop.Data.Models;
using Shop.Models.Country;
using Shop.Models.ShoppingCart;

namespace Shop.Models.Order
{
    public class InputOrderViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street1 { get; set; }

        public string? Street2 { get; set; }

        [Required(ErrorMessage = "Street number is required.")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Post code is required.")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Please select a country.")]
        public int SelectedCountryId { get; set; }

        public Guid ShoppingCartId { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }
        
        public IEnumerable<ShoppingCartProductsViewModel> Products { get; set; } 
    }
}