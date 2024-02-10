using Microsoft.AspNetCore.Mvc;
using Shop.Services.ProductService.Contract;
using Shop.Services.ShopService.Contract;

namespace Shop.Controllers
{
    public class DetailsController : BaseController
    {
       
        private readonly IDetailsService detailsService;
        private readonly IProductService productService;

        public DetailsController(IDetailsService detailsService,IProductService productService)
        {
            this.detailsService = detailsService; 
            this.productService = productService;
        }
       

         public async Task<IActionResult> Details(int id)
         {
             var product = await detailsService.GetProductAsync(id);
            return View(product);
        }
         public async Task<IActionResult> Add(int productId)
         {
             string check = GetUserId();
             Console.WriteLine(check);
             if (check != null)
             {
                 await productService.AddToShoppingCartAsync(Guid.Parse(GetUserId()), productId);
                 return RedirectToAction("Cart","ShoppingCart");
             }
             else
             {
                return RedirectToAction("","Home");
            }
        }

         //public async Task<IActionResult> Edit(int productId)
         //{

         //}

    }
}
