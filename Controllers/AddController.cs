using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class AddController : BaseController
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
