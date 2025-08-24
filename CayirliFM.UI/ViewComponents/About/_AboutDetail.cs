using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.About
{
    public class _AboutDetail : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutDetail(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.TGetById(3);
            return View(values);
        }
    }
}
