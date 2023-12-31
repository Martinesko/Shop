﻿using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Category;
using Shop.Models.Color;
using Shop.Models.Make;
using Shop.Models.ModelType;
using Shop.Models.Product;
using Shop.Models.Size;
using Shop.Services.ProductService.Contract;

namespace Shop.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext dbContext;

        public ProductService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddProductViewModel> GetAddedProduct()
        {
            var categories = await dbContext.Categories.Select(c=>new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            var makes = await dbContext.Makes.Select(m=> new MakeViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync(); 
            var colors = await dbContext.Colors.Select(m=> new ProductColorViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync();
             var modelTypes = await dbContext.ModelTypes.Select(m=> new ModelTypeViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync(); 
             var size = await dbContext.Sizes.Select(s=> new ProductSizeViewModel()
            {
                Id = s.Id,
                Name = s.Name,
            }).ToListAsync();
            


            return new AddProductViewModel
            {
                Categories = categories,
                Makes = makes,
                Colors = colors,
                ModelTypes = modelTypes,
                Sizes = size
            };

        }
        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product product = new Product()
            {
                MakeId = model.MakeId,
                ModelTypeId = model.ModelTypeId,
                Price = model.Price,
                ColorId = model.ColorId,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Model = model.ModelName,
                SizeId = model.SizeId,
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToShoppingCartAsync(Guid userId,int ProductId )
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == ProductId);

            var shoppingCart = dbContext.ShoppingCarts.FirstOrDefault(p => p.UserId == userId);
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

        public async Task RemoveProductAsync(int ProductId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AddProductViewModel> GetProductForEdit(int productId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            var categories = await dbContext.Categories.Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            var makes = await dbContext.Makes.Select(m => new MakeViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync();
            var colors = await dbContext.Colors.Select(m => new ProductColorViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync();
            var modelTypes = await dbContext.ModelTypes.Select(m => new ModelTypeViewModel()
            {
                Id = m.Id,
                Name = m.Name,
            }).ToListAsync();
            var size = await dbContext.Sizes.Select(s => new ProductSizeViewModel()
            {
                Id = s.Id,
                Name = s.Name,
            }).ToListAsync();

            return new AddProductViewModel()
                {
                    ProductId = product.Id,
                    Categories = categories,
                    Makes = makes,
                    Colors = colors,
                    ModelTypes = modelTypes,
                    Sizes = size,
                    MakeId = product.MakeId,
                    ModelTypeId = product.ModelTypeId,
                    Price = product.Price,
                    ColorId = product.ColorId,
                    CategoryId = product.CategoryId,
                    ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    ModelName = product.Model,
                    SizeId = product.SizeId,
                };
        }

        public async Task SaveProductAsync(AddProductViewModel model,int productId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);

                product.MakeId = model.MakeId;
                product.ModelTypeId = model.ModelTypeId;
                product.Price = model.Price;
                product.ColorId = model.ColorId;
                product.CategoryId = model.CategoryId;
                product.ImageUrl = model.ImageUrl;
                product.Description = model.Description;
                product.Model = model.ModelName;
                product.SizeId = model.SizeId;
            
            await dbContext.SaveChangesAsync();
        }
    }
}
