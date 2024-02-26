using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models.Order;
using Shop.Services.OrderService.Contract;
using Shop.Services.ProductService.Contract;
using Shop.Services.ShoppingCartService.Contract;

namespace Shop.Controllers
{
    public class CheckOutController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService shoppingCartService;

        public CheckOutController(IOrderService orderService, IShoppingCartService shoppingCartService)
        {
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
        }
       

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {

            var Id = Guid.Parse(GetUserId());
            var model = await orderService.GetOrderAdressAsync(Id);
            var total = model.Products.Sum(p=>p.Price)+10;

            ViewBag.Total = $"{total:f2}";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(InputOrderViewModel model)
        {
            var Id = Guid.Parse(GetUserId());
            var m = await orderService.GetOrderAdressAsync(Id);
            if (model.City == null || model.Street1 == null || model.StreetNumber == null || model.PostCode == null || model.SelectedCountryId == null)
            {
                model.Countries = m.Countries;
                model.Products = m.Products;
                return View(model);
            }

            await orderService.MakeOrder(Guid.Parse(GetUserId()), model);
            return RedirectToAction("Index","Home");
        }
    }
}
