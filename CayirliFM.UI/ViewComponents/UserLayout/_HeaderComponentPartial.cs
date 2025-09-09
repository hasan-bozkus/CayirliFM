using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.SocialMediaAccountsDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.UserLayout
{
    public class _HeaderComponentPartial : ViewComponent
    {
        private readonly ISocialMediaAccountsService _socialMediaAccountsService;
        private readonly IMapper _mapper;

        public _HeaderComponentPartial(ISocialMediaAccountsService socialMediaAccountsService, IMapper mapper)
        {
            _socialMediaAccountsService = socialMediaAccountsService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultSocialMediaAcconutDto>>(await _socialMediaAccountsService.TGetListAll());
            return View(values);
        }
    }
}
