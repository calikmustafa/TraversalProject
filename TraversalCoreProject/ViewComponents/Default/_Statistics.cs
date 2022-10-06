using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.Destinations = c.Destinations.Count();
            ViewBag.Guide = c.Guides.Count();
            ViewBag.Customer = "285";
            return View();
        }
    }
}
