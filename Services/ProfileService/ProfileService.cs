using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Country;
using Shop.Models.Profile;
using Shop.Services.ProfileService.Contract;
using static Shop.Common.EntityValidationConstants;

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
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

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
            var user = dbContext.Users.FirstOrDefault(u => u.Id == UserId);

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
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);

            var address = await dbContext.Addresses.FirstOrDefaultAsync(u => u.Id == user.AddressId);

            var countries = dbContext.Countries.Select(c => new CountryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            });
            if (address == null)
            {
                var newAddress = new Address();
                newAddress.City = "";
                newAddress.CountryId = 1;
                newAddress.PostCode = "";
                newAddress.Street1 = "";
                newAddress.Street2 = "";
                newAddress.StreetNumber = "";
                await dbContext.Addresses.AddAsync(newAddress);
                user.AddressId = newAddress.Id;
                user.Address = address;
                address = newAddress;
                await dbContext.SaveChangesAsync();
            }

            user.Address = address;
            await dbContext.SaveChangesAsync();

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

        public async Task SaveAddressChangesAsync(AddressViewModel model, Guid userId)
        {
            var user = await dbContext.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var newAddress = new Address();
            newAddress.City = model.City;
            newAddress.PostCode = model.PostCode;
            newAddress.Street1 = model.Street1;
            newAddress.Street2 = model.Street2;
            newAddress.CountryId = model.SelectedCountryId;
            newAddress.StreetNumber = model.StreetNumber;
            user.AddressId = newAddress.Id;
            user.Address = newAddress;
             dbContext.SaveChanges();
        }
    }
}
