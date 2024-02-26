using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Shop.Models.Product;
using Shop.Services.ProductService.Contract;
using Shop.Services.UsersService.Contract;
using System.Data;

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IProductService productService;
        private readonly IUsersService usersService;
        public AdminPanelController(IProductService productService, IUsersService usersService)
        {
            this.productService = productService;
            this.usersService = usersService;
        }

        public IActionResult Dashboard()
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
            var flag = await usersService.RemoveUserAsync(UserId);
            if (flag == false)
            {
                return RedirectToAction("Error500", "Error");
            }
            return RedirectToAction("Users", "AdminPanel");
        }

        public async Task<IActionResult> GrantAdmin(string userId)
        {
            Guid Id = Guid.Parse(userId);
            await usersService.GrandAdminUserAsync(Id);
            return RedirectToAction("Users", "AdminPanel");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int productId)
        {
            await productService.RemoveProductAsync(productId);
            return RedirectToAction("All","Shop");
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            AddProductViewModel model = await productService.GetAddedProduct();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            var m = await productService.GetAddedProduct();
            if (!ModelState.IsValid)
            {
                model.ModelTypes = m.ModelTypes;
                model.Sizes = m.Sizes;
                model.Makes = m.Makes;
                model.ModelTypes = m.ModelTypes;
                model.Categories = m.Categories;
                model.Colors = m.Colors;

                return View(model);
            }
            await productService.AddProductAsync(model);
            return RedirectToAction("All", "Shop");
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int productid)
        {
            AddProductViewModel model = await productService.GetProductForEdit(productid);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(AddProductViewModel model)
        {
                var m = await productService.GetAddedProduct();
                if (!ModelState.IsValid)
                {
                    model.ModelTypes = m.ModelTypes;
                    model.Sizes = m.Sizes;
                    model.Makes = m.Makes;
                    model.ModelTypes = m.ModelTypes;
                    model.Categories = m.Categories;
                    model.Colors = m.Colors;

                    return View(model);
                }


            await productService.SaveProductAsync(model,model.ProductId);
            return RedirectToAction("All", "Shop");
        }
    }
}
