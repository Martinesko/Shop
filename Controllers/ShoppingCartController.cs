using Microsoft.AspNetCore.Mvc;
using Shop.Services.ShoppingCartService.Contract;
using Shop.Services.ShopService;
using Shop.Services.ShopService.Contract;

namespace Shop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IActionResult Cart()
        { 
            var products = shoppingCartService
                .GetUserShoppingCartPorductsAsync(Guid.Parse(GetUserId())).Result;
            var total = products.Sum(p => p.Price);
            
            ViewBag.Total = $"{total:f2}";


            return View(products);
        }
        
        //public IActionResult Remove(string productId)
        //{
        //    var UserId = Guid.Parse(GetUserId());
        //    shoppingCartService.RemoveShoppingCartProductAsync(int.Parse(productId),UserId);

        //    return RedirectToAction("Cart","ShoppingCart");
        //}
        
    }
}
