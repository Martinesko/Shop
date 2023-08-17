using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Shop.Models;
using Shop.Models.Product;
using Shop.Services.ProductService;
using Shop.Services.ProductService.Contract;
using Shop.Services.UsersService.Contract;

namespace Shop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService productService;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}