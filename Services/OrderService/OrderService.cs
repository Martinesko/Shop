using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Category;
using Shop.Models.Color;
using Shop.Models.Country;
using Shop.Models.Make;
using Shop.Models.ModelType;
using Shop.Models.Order;
using Shop.Models.Product;
using Shop.Models.ShoppingCart;
using Shop.Models.Size;
using Shop.Services.OrderService.Contract;


namespace Shop.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext dbContext;

        public OrderService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OrderViewModel> GetOrderAdressAsync(Guid userId)
        {
            var countries = await dbContext.Countries.Select(c => new CountryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            var userShoppingCart = await dbContext.ShoppingCarts
                .FirstOrDefaultAsync(sc => sc.UserId == userId);


            var Id = userShoppingCart.Id;

            var products = await dbContext.ShoppingCartItems
                .Where(sci => sci.ShoppingCartId == Id)
                .Select(p => new ShoppingCartProductsViewModel()
                {
                    Id = p.ProductId,
                    Model = p.Product.Model,
                    Price = p.Product.Price
                }).ToListAsync();

            var address = new OrderViewModel()
            {
                Countries = countries,
                Products = products
            };
            return address;
        }
    }
}
