using Shop.Models.Shop;

namespace Shop.Services.ShopService.Contract
{
    public interface IShopService
    {
        public Task<IEnumerable<ShopAllViewModel>> GetAllProductsAsync();
    }
}
