using Shop.Data;
using Shop.Models.Shop;
using Shop.Services.ShopService.Contract;
using Microsoft.EntityFrameworkCore;

namespace Shop.Services.ShopService
{
    public class DetailsService : IDetailsService
    {

        private readonly ShopDbContext dbContext;

        public DetailsService(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ShopDetailsViewModel> GetProductAsync(int id)
        {
              return await dbContext.Products.Where(p => p.Id == id).Select(product => new ShopDetailsViewModel()
             {
                 Id = product.Id,
                 Model = product.Model,
                 Make = product.Make.Name,
                 ModelType = product.ModelType.Name,
                 Category = product.Category.Name,
                 ImageUrl = product.ImageUrl,
                 Description = product.Description,
                 Color = product.Color.Name,
                 Price = product.Price,
                 Size = product.Size.Name
             }).FirstOrDefaultAsync();
        }

      
    }
}
