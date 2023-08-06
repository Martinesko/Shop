using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models.Category;
using Shop.Services.ColorService.Contract;

namespace Shop.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly ShopDbContext dbContext;
        public ColorService(ShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> GetColorsAsync()
        {
            IEnumerable<ProductCategoryViewModel> colors = await dbContext.Colors.AsNoTracking().Select(x => new ProductCategoryViewModel(){Id=x.Id,Name=x.Name}).ToListAsync();

            return colors;
        }
    }
}
