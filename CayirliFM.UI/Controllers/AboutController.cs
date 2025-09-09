using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.isActive = "About";
            return View();
        }
    }
}
