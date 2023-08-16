using Microsoft.AspNetCore.Mvc;
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

           var firstName = "-";
           var surname = "-";
           if (user.FirstName != null)
           {
            firstName = user.FirstName;
           }

           if (user.Surname != null)
           {
               surname = user.Surname;
           }
           return new ProfileViewModel()
           {
               Surname = surname,
               Firstname = firstName,
               Phone = user.PhoneNumber,
               Email = user.Email,
           };
        }

        public async Task EditProfileAsync(Guid UserId, ProfileViewModel model)
        {
           var user = dbContext.Users.FirstOrDefault(u=>u.Id == UserId);

           user.FirstName = model.Firstname;
           user.Surname = model.Surname;
           user.Email = model.Email;
           user.NormalizedEmail = model.Email;
           user.NormalizedUserName = model.Email;
           user.UserName = model.Email;
           user.PhoneNumber = model.Phone;
           await dbContext.SaveChangesAsync();
        }
    }
}
