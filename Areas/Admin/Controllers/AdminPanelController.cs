using Microsoft.AspNetCore.Mvc;
using Shop.Controllers;
using Shop.Models.Product;
using Shop.Services.ProductService.Contract;
using Shop.Services.UsersService.Contract;

namespace Shop.Areas.Admin.Controllers
{
    public class AdminPanelController : BaseController
    { 
        private readonly IProductService productService;
        private readonly IUsersService usersService;
        public AdminPanelController(IProductService productService, IUsersService usersService)
        {
            this.productService = productService;
            this.usersService = usersService;
        }


        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = usersService.GetAllUsersAsync();
            return View(users.Result);
        }
        
        public async Task<IActionResult> RemoveUser(string deleteButton)
        {
            var UserId = Guid.Parse(deleteButton);
            await usersService.RemoveUserAsync(UserId);
            return RedirectToAction("Users", "AdminPanel");
        }

        public async Task<IActionResult> GrantAdmin(string userId)
        {
            Guid Id = Guid.Parse(userId);
            await usersService.GrandAdminUserAsync(Id);
            return RedirectToAction("Users", "AdminPanel");
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
            return RedirectToAction("DashBoard", "AdminPanel");
        }
        
    }
}
