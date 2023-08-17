using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static Shop.Common.EntityValidationConstants.User;

namespace Shop.Data.Models
{
    public class CustomUser : IdentityUser<Guid>
    {
        public CustomUser()
        {
            this.Id = Guid.NewGuid();
        }

        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string? FirstName { get; set; }
        [StringLength(SurNameMaxLength, MinimumLength = SurNameMinLength)]
        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
