using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var valuesIdentityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = valuesIdentityUser.Name + " " + valuesIdentityUser.Surname;
            ViewBag.userImage = valuesIdentityUser.ImageUrl;
            return View();
        }
    }
}
