using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.About
{
    public class _AboutStrategyDetail : ViewComponent
    {
        private readonly IStrategyService _strategyService;

        public _AboutStrategyDetail(IStrategyService strategyService)
        {
            _strategyService = strategyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _strategyService.TGetStrategyListWithStatusTrue();
            return View(values);
        }
    }
}
