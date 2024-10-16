using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
