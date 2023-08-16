using Microsoft.AspNetCore.Mvc;
using Shop.Models.Profile;
using Shop.Services.ProductService.Contract;
using Shop.Services.ProfileService.Contract;
using Shop.Services.ShopService.Contract;

namespace Shop.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        
        }

        public IActionResult Profile()
        {
            var userid = Guid.Parse(GetUserId());
            var model = profileService.GetProfileAsync(userid);
            return View(model.Result);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userid = Guid.Parse(GetUserId());
            var model = profileService.GetProfileAsync(userid);
            return View(model.Result);
        }

        [HttpPost]
        public IActionResult Edit(ProfileViewModel model)
        {
            var userid = Guid.Parse(GetUserId());
            profileService.EditProfileAsync(userid, model);
            return RedirectToAction("Profile","Profile");
        }
    }
}
