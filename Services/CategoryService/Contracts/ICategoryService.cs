using Shop.Data.Models;

namespace Shop.Services.CategoryService.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Product>> AllCategoriesAsync();
    }
}
