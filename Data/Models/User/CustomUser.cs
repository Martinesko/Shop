using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop.Data.Models
{
    public class CustomUser : IdentityUser<Guid>
    {
        public CustomUser()
        {
            this.Id = Guid.NewGuid();
        }

        public string? FirstName { get; set; }
        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
