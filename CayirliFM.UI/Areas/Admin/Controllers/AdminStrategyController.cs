using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.StrategyDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStrategyController : Controller
    {
        private readonly IStrategyService _strategyService;
        private readonly IMapper _mapper;

        public AdminStrategyController(IStrategyService strategyService, IMapper mapper)
        {
            _strategyService = strategyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultStrategyDto>>(await _strategyService.TGetListAll());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateStrategy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStrategy(CreateStrategyDto createStrategyDto)
        {
            createStrategyDto.StrategyStatus = false;
            var result = _mapper.Map<Strategy>(createStrategyDto);
            _strategyService.TCraete(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteStrategy(int id)
        {
            var result = await _strategyService.TGetById(id);
            _strategyService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStrategy(int id)
        {
            var result = _mapper.Map<UpdateStrategyDto>(await _strategyService.TGetById(id));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStrategy(UpdateStrategyDto updateStrategyDto)
        {
            var result = _mapper.Map<Strategy>(updateStrategyDto);
            _strategyService.TUpdate(result);
            return RedirectToAction("Index");
        }
    }
}
