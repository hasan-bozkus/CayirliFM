using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Admin.AdminLayout
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
