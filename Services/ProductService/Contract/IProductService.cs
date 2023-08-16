using Microsoft.AspNetCore.Mvc;
using Shop.Models.Product;

namespace Shop.Services.ProductService.Contract
{
    public interface IProductService
    {
        public Task<AddProductViewModel> GetAddedProduct();
        public Task AddProductAsync(AddProductViewModel model);
        //public Task AddToCartAsync(Guid userId, int productId);
        Task AddToShoppingCartAsync(Guid userId, int ProductId);
        Task<AddProductViewModel> EditProduct(int ProductId);

    }
}
