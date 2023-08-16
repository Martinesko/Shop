using Shop.Data.Models;

namespace Shop.Models.Profile
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Data.Models.Address? City { get; set; }
    }
}
