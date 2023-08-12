//using Microsoft.AspNetCore.Mvc;
//using Shop.Controllers;
//using Shop.Models.Product;
//using Shop.Services.ProductService;
//using Shop.Services.ProductService.Contract;

//namespace Shop
//{
//    public class AddController : BaseController
//    {
//            private readonly IProductService productService;

//            public AddController(IProductService productService)
//            {
//                this.productService = productService;
//            }

//        [HttpGet]
//        public async Task<IActionResult> Add()
//        {
//            AddProductViewModel model = await productService.GetAddedProduct();

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(AddProductViewModel model)
//        {
//            if (ModelState.IsValid == false)
//            {
//                return RedirectToAction("Add");
//            }
//            await productService.AddProductAsync(model);
//            return RedirectToAction("Index");
//        }
//    }
//}

 