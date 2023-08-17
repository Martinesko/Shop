using Microsoft.AspNetCore.Mvc;
using Shop.Models.Product;

namespace Shop.Services.ProductService.Contract
{
    public interface IProductService
    {
        public Task<AddProductViewModel> GetAddedProduct();
        public Task AddProductAsync(AddProductViewModel model);
        Task AddToShoppingCartAsync(Guid userId, int ProductId);
        Task RemoveProductAsync(int ProductId);
        Task<AddProductViewModel> GetProductForEdit(int productId);
        Task SaveProductAsync(AddProductViewModel model, int productId);

    }
}
