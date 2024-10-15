using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Controllers
{
	public class UserLayoutController : Controller
	{
		public IActionResult _UserLayout()
		{
			return View();
		}

		public IActionResult HeadPartial()
		{
			return PartialView();
		}

		public IActionResult HeaderPartial()
		{
			return PartialView();
		}

		public IActionResult NavbarPartial()
		{
			return PartialView();
		}

		public IActionResult FooterPartial()
		{
			return PartialView();
		}

		public IActionResult ScriptPartial()
		{
			return PartialView();
		}
	}
}
