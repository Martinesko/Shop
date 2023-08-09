using Microsoft.AspNetCore.Mvc;
using Shop.Services.ShopService;

namespace Shop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        
        public IActionResult Cart()
        {

            return View();
        }
    }
}
