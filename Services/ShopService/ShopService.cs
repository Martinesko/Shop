using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.Shop;
using Shop.Services.ShopService.Contract;

namespace Shop.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly ShopDbContext dbContext;

        public ShopService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ShopAllViewModel>> GetAllProductsAsync()
        {
            return await dbContext.Products.Select(p=> new ShopAllViewModel()
            {
                Id = p.Id,
                Model = p.Model,
                ModelType = p.ModelType.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Make = p.Make.Name
            }).ToListAsync();
        }
    }
}
