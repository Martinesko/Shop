using Microsoft.AspNetCore.Mvc;
using Shop.Services.ShopService.Contract;

namespace Shop.Controllers
{
    public class DetailsController : BaseController
    {
       
        private readonly IDetailsService detailsService;

        public DetailsController(IDetailsService detailsService)
        {
            this.detailsService = detailsService;
        }

         public IActionResult Details(int id)
         {
             var product = detailsService.GetProductAsync(id);
            return View();
        }
    }
}
