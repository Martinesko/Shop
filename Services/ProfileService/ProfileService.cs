using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Profile;
using Shop.Services.ProfileService.Contract;

namespace Shop.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly ShopDbContext dbContext;

        public ProfileService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProfileViewModel> GetProfileAsync(Guid userId)
        {
           var user = await dbContext.Users.FirstOrDefaultAsync(u=>u.Id == userId);

           return new ProfileViewModel()
           {
               Name = user.UserName,
               Email = user.Email,
           };
        }

    }
}
