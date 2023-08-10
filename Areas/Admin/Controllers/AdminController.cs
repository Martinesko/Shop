using Microsoft.AspNetCore.Mvc;
using Shop.Controllers;
using Shop.Models.Product;
using Shop.Services.ProductService.Contract;

namespace Shop.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    { 
        private readonly IProductService productService;
        public AdminController(IProductService productService)
        {
            this.productService = productService;
        }


        public IActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddProductViewModel model = await productService.GetAddedProduct();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Add");
            }
            await productService.AddProductAsync(model);
            return RedirectToAction("Admin","Admin");
        }
    }
}
