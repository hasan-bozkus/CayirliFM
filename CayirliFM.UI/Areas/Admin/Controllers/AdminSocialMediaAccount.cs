using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.SocialMediaAccountsDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSocialMediaAccount : Controller
    {
        private readonly ISocialMediaAccountsService _socialMediaAccountsService;
        private readonly IMapper _mapper;

        public AdminSocialMediaAccount(ISocialMediaAccountsService socialMediaAccountsService, IMapper mapper)
        {
            _socialMediaAccountsService = socialMediaAccountsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values =  _mapper.Map<List<ResultSocialMediaAcconutDto>>(await _socialMediaAccountsService.TGetListAll());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaAcconutDto createSocialMediaAcconutDto)
        {
            createSocialMediaAcconutDto.SocialMediaCreateAtTime = DateTime.Parse(DateTime.Now.ToString());
            var result = _mapper.Map<SocialMediaAccounts>(createSocialMediaAcconutDto);
            _socialMediaAccountsService.TCraete(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var result = await _socialMediaAccountsService.TGetById(id);
            _socialMediaAccountsService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var result = _mapper.Map<UpdateSocialMediaAccountDto>(await _socialMediaAccountsService.TGetById(id));
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaAccountDto updateSocialMediaAccountDto)
        { 
            var result = _mapper.Map<SocialMediaAccounts>(updateSocialMediaAccountDto);
            _socialMediaAccountsService.TUpdate(result);
            return RedirectToAction("Index");
        }
    }
}
