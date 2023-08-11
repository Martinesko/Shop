using Microsoft.AspNetCore.Mvc;
using Shop.Controllers;
using Shop.Models.Product;
using Shop.Services.ProductService.Contract;
using Shop.Services.UsersService.Contract;

namespace Shop.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    { 
        private readonly IProductService productService;
        private readonly IUsersService usersService;
        public AdminController(IProductService productService, IUsersService usersService)
        {
            this.productService = productService;
            this.usersService = usersService;
        }


        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = usersService.GetAllUsersAsync();
            return View(users.Result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(string deleteButton)
        {
            var UserId = Guid.Parse(deleteButton);
            await usersService.RemoveUserAsync(UserId);
            return RedirectToAction("Admin", "Admin");
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
