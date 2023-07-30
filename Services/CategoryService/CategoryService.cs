using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models.Category;
using Shop.Services.CategoryService.Contracts;

namespace Shop.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext dbContext;
        public CategoryService(ShopDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<ProductCategoryViewModel> productCategoryViewModels = 
                await dbContext.Categories.AsNoTracking()
                    .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            return productCategoryViewModels;
        }

        public async Task<IEnumerable<string>> CategoryNamesAsync()
        {
            IEnumerable<string> categoryNames = await dbContext.Categories.AsNoTracking().Select(x => x.Name).ToListAsync();
            return categoryNames;
        }
    }
}
