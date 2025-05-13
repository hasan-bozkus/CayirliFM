using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.WelcomeToOurSiteDto;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminWelcomeToOurSiteController : Controller
    {
        private readonly IWelcomeToOurSiteService _welcomeToOurSiteService;
        private readonly IMapper _mapper;

        public AdminWelcomeToOurSiteController(IWelcomeToOurSiteService welcomeToOurSiteService, IMapper mapper)
        {
            _welcomeToOurSiteService = welcomeToOurSiteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultWelcomeToOurSiteDto>>(await _welcomeToOurSiteService.TGetListAll());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateWelcomeToOurSite()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWelcomeToOurSite(CreateWelcomeToOurSiteDto createWelcomeToOurSiteDto)
        {
            createWelcomeToOurSiteDto.Status = "Onay Bekliyor";
            var result = _mapper.Map<WelcomeToOurSite>(createWelcomeToOurSiteDto);
            _welcomeToOurSiteService.TCraete(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWelcomeToOurSite(int id)
        {
            var values = await _welcomeToOurSiteService.TGetById(id);
            _welcomeToOurSiteService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWelcomeToOurSite(int id)
        {
            var values = _mapper.Map<UpdateWelcomeToOurSiteDto>(await _welcomeToOurSiteService.TGetById(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateWelcomeToOurSite(UpdateWelcomeToOurSiteDto updateWelcomeToOurSiteDto)
        {
            var result = _mapper.Map<WelcomeToOurSite>(updateWelcomeToOurSiteDto);
            _welcomeToOurSiteService.TUpdate(result);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToApproved(int id)
        {
            _welcomeToOurSiteService.TChangeToApproved(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToDeApproved(int id)
        {
            _welcomeToOurSiteService.TChangeToDeApproved(id);
            return RedirectToAction("Index");
        }
    }
}
