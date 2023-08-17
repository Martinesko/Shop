using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Country;
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

        public async Task<AddressViewModel> GetAddress(Guid UserId)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u=>u.Id == UserId);

            var address = await dbContext.Addresses.FirstOrDefaultAsync(u=>u.Id == user.AddressId);

            var countries = dbContext.Countries.Select(c=>new CountryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            });

            return new AddressViewModel()
            {
                Id = address.Id,
                City = address.City,
                PostCode = address.PostCode,
                Street1 = address.Street1,
                Street2 = address.Street2,
                SelectedCountryId = address.CountryId,
                StreetNumber = address.StreetNumber,
                Countries = countries
            };
        }

        public async Task SaveAddressChangesAsync(AddressViewModel model,Guid userId)
        {
            var address = new Address();

            address.City = model.City;
            address.PostCode = model.PostCode;
            address.Street1 = model.Street1;
            address.Street2 = model.Street2;
            address.CountryId = model.SelectedCountryId;
            address.StreetNumber = model.StreetNumber;

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            
            dbContext.Addresses.Add(address);
            user.AddressId = address.Id;

           await dbContext.SaveChangesAsync();
        }
    }
}
