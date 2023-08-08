using Microsoft.AspNetCore.Mvc;
using Shop.Services.ProductService.Contract;
using Shop.Services.ShopService.Contract;

namespace Shop.Controllers
{
    public class ShopController : BaseController
    {
        private readonly IShopService shopService;

        public ShopController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public async Task<IActionResult> All()
        {
            var products = await shopService.GetAllProductsAsync();
            return View(products);
        }
    }
}
