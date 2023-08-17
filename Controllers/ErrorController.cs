using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ErrorController : BaseController
    {

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }
}
