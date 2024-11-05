using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Admin.AdminLayout
{
    public class _HeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
