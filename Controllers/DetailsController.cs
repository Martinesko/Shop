using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class DetailsController : BaseController
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
