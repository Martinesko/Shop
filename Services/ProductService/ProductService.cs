using Microsoft.EntityFrameworkCore;
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
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Model = model.Model,
                SizeId = model.SizeId,
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddToCartAsync(Guid userId,int productId)
        {
            var shoppingCart = dbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    ShoppingCartItems = new List<ShoppingCartItem>()
                };
            }
            var shoppingcartItem = new ShoppingCartItem()
            {
                ShoppingCartId = shoppingCart.Id,
                ProductId = productId
            };
            await dbContext.ShoppingCartItems.AddAsync(shoppingcartItem);
            await dbContext.SaveChangesAsync();
        }
    }
}
