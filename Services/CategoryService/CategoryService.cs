using Shop.Data;
using Shop.Data.Models;
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

        public async Task<IEnumerable<Product>> AllCategoriesAsync()
        {
            IEnumerable<>
        }
    }
}
