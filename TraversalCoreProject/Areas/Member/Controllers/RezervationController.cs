using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class RezervationController : Controller
    {
        DestinationManager destinationManager=new DestinationManager(new EfDestinationDal());
        RezervationManager rezervationManager=new RezervationManager(new EfRezervationDal());
        private readonly UserManager<AppUser> userManager;

        public RezervationController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentRezervation()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = rezervationManager.GetListWithRezervationByAccepted(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyOldRezervation()
        {

            var values = await userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = rezervationManager.GetListWithRezervationByPrevious(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyApprovalRezervation()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            var valuesList=rezervationManager.GetListWithRezervationByWaitApproval(values.Id);
            return View(valuesList);
        }
        [HttpGet]
        public IActionResult NewRezervation()
        {
            List<SelectListItem>selectListItems=(from x in destinationManager.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text=x.City,
                                                     Value=x.DestinationID.ToString()
                                                 }).ToList();
            ViewBag.v = selectListItems;
            return View();
        }

        [HttpPost]
        public IActionResult NewRezervation(Rezervation rezervation)
        {
            rezervation.AppUserId = 1;
            rezervation.Status = "Onay Bekliyor";
            rezervationManager.TAdd(rezervation);
            return RedirectToAction("MyCurrentRezervation");
        }
    }
}
