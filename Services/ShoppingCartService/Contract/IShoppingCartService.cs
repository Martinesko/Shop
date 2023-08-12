using Shop.Models.ShoppingCart;

namespace Shop.Services.ShoppingCartService.Contract
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCartProductsViewModel>> GetUserShoppingCartPorductsAsync(Guid userId);
        //Task RemoveShoppingCartProductAsync(int productId,Guid UserId);
    }
}
