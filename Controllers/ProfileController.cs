using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ProfileController : BaseController
    {

        public IActionResult Profile()
        {
            var userid = Guid.Parse(GetUserId());
            return View();
        }
    }
}
