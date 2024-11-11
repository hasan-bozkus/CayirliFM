using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Admin.AdminLayout
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
