using Shop.Models.Category;

namespace Shop.Services.ColorService.Contract
{
    public interface IColorService
    {
       public Task<IEnumerable<ProductCategoryViewModel>> GetColorsAsync();
    }
}
