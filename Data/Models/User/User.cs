using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }
        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
