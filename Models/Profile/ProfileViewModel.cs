using Shop.Data.Models;

namespace Shop.Models.Profile
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address City { get; set; }
    }
}
