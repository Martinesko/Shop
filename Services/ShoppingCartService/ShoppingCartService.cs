﻿using Microsoft.EntityFrameworkCore;
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

        //public async Task RemoveShoppingCartProductAsync(int productId)
        //{ 
        //    var item = await dbContext.ShoppingCartItems.FirstOrDefaultAsync(sci => sci.ProductId == productId);

        //    dbContext.ShoppingCartItems.Remove(item);
        //    await dbContext.SaveChangesAsync();
        //}
    }
}
