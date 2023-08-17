using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Build.Framework;
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

        public async Task<InputOrderViewModel> GetOrderAdressAsync(Guid userId)
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

            var address = new InputOrderViewModel()
            {
                ShoppingCartId = Id,
                Countries = countries,
                Products = products
            };
            return address;
        }

        public async Task MakeOrder(Guid Id,InputOrderViewModel model)
        {
            var shoppingCartId = dbContext.ShoppingCarts.FirstOrDefaultAsync(sc => sc.UserId == Id).Result;
            var address = new Address()
            {
                City = model.City,
                CountryId = model.SelectedCountryId,
                PostCode = model.PostCode,
                Street1 = model.Street1,
                Street2 = model.Street2,
                StreetNumber = model.StreetNumber
            };
            await dbContext.Addresses.AddAsync(address);

            var order = new Order()
            {
                UserId = Id,
                OrderDate = DateTime.Now,
                ShippingAddressId = address.Id,
                ShoppingCartId = shoppingCartId.Id,
            };

            var shoppingcart = new ShoppingCart()
            {
                UserId = Id
            };
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);

            user.AddressId = address.Id;
            dbContext.ShoppingCarts.Remove(shoppingcart);

            dbContext.ShoppingCarts.Add(shoppingcart);
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
