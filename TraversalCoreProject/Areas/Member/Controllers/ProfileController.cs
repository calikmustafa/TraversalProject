using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                Name = values.Name,
                Surname=values.Surname,
                PhoneNumber=values.PhoneNumber,
                Mail=values.Email
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViewModel.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();//KAYNAK
                var extension=Path.GetExtension(userEditViewModel.Image.FileName);//UZANTI
                var imageName=Guid.NewGuid()+extension;//İMAGE BENZERSİZ ANAHTARI
                var saveLocation=resource+ "/wwwroot/userImages/"+imageName;//KAYDEDİLECEK LOKASYON
                var stream=new FileStream(saveLocation, FileMode.Create);
                await userEditViewModel.Image.CopyToAsync(stream);//AKIŞDAN GELEN DEĞERE KOPYALA
                user.ImageUrl = imageName;
            }
            user.Name=userEditViewModel.Name;
            user.Surname=userEditViewModel.Surname;
            user.PasswordHash=_userManager.PasswordHasher.HashPassword(user,userEditViewModel.Password);
            var result=await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
