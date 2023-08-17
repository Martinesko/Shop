using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.ShoppingCart;
using Shop.Services.ShoppingCartService.Contract;

namespace Shop.Services.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ShopDbContext dbContext;

        public ShoppingCartService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ShoppingCartProductsViewModel>> GetUserShoppingCartPorductsAsync(Guid userId)
        {
            var userShoppingCart = await dbContext.ShoppingCarts
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            if (userShoppingCart == null)
            {
                userShoppingCart = new ShoppingCart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                };
            }

            var Id = userShoppingCart.Id;

            var products = await dbContext.ShoppingCartItems
                .Where(sci => sci.ShoppingCartId == Id)
                .Select(p => new ShoppingCartProductsViewModel()
                {
                    ShoppingCartId = Id,
                    Id = p.ProductId,
                    Model = p.Product.Model,
                    Size = p.Product.Size.Name,
                    Price = p.Product.Price
                }).ToListAsync();
            await dbContext.SaveChangesAsync();
            return products;
        }

        public async Task RemoveFromShoppingCartAsync(Guid userId, int ProductId)
        {
            // Find the user's shopping cart
            var shoppingCart = dbContext.ShoppingCarts.FirstOrDefault(p => p.UserId == userId);

            // If the cart doesn't exist or is empty, there's nothing to remove
            if (shoppingCart == null)
            {
                return;
            }

            // Find the specific shopping cart item that corresponds to the given product ID
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(item => item.ProductId == ProductId && item.ShoppingCartId == shoppingCart.Id);

            // If the item exists in the cart, remove it
            if (shoppingCartItem != null)
            {
                dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
