using Shop.Data.Models;
using Shop.Models.Category;

namespace Shop.Services.CategoryService.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductCategoryViewModel>> AllCategoriesAsync();
        Task<IEnumerable<string>> CategoryNamesAsync();
    }
}
