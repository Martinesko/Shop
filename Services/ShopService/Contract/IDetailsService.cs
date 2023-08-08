using Shop.Models.Shop;

namespace Shop.Services.ShopService.Contract
{
    public interface IDetailsService
    {
        public Task<ShopDetailsViewModel> GetProductAsync(int id);
    }
}
