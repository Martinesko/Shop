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

        public async Task AddToShoppingCartAsync(int ProductId, Guid userId)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == ProductId);

            var shoppingCart = dbContext.ShoppingCarts.FirstOrDefault(p => p.Id == userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                };
                await dbContext.ShoppingCarts.AddAsync(shoppingCart);
            }

            var shoppingCartItem = new ShoppingCartItem()
            {
                ProductId = ProductId,
                ShoppingCartId = shoppingCart.Id,
            };

            await dbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            await dbContext.SaveChangesAsync();
        }
    }
}
