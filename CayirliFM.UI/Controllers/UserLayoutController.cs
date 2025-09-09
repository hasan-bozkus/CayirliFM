using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.SocialMediaAccountsDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Controllers
{
	public class UserLayoutController : Controller
	{	
		private readonly ISocialMediaAccountsService _socialMediaAccountsService;
		private readonly IMapper _mapper;

        public UserLayoutController(ISocialMediaAccountsService socialMediaAccountsService, IMapper mapper)
        {
            _socialMediaAccountsService = socialMediaAccountsService;
            _mapper = mapper;
        }

        public IActionResult _UserLayout()
		{
			return View();
		}

		public IActionResult HeadPartial()
		{
			return PartialView();
		}

		public async Task<IActionResult> HeaderPartial()
		{
			var values = _mapper.Map<List<ResultSocialMediaAcconutDto>>(await _socialMediaAccountsService.TGetListAll());
			return PartialView(values);
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
