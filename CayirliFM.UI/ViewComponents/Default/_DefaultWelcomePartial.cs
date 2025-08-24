using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.WelcomeToOurSiteDto;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Default
{
    public class _DefaultWelcomePartial : ViewComponent
    {
        private readonly IWelcomeToOurSiteService _welcomeToOurSiteService;
        private readonly IMapper _mapper;

        public _DefaultWelcomePartial(IWelcomeToOurSiteService welcomeToOurSiteService, IMapper mapper)
        {
            _welcomeToOurSiteService = welcomeToOurSiteService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<ResultGetWelcomeToOurSiteDto>(await _welcomeToOurSiteService.TGetById(1));
            return View(values);
        }
    }
}
