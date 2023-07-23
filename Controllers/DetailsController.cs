using Microsoft.AspNetCore.Mvc;

namespace AnevAuto.Controllers
{
    public class DetailsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
