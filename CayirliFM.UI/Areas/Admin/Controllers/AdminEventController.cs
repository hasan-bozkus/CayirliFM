using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.CategoryEventDtos;
using CayirliFM.DtoLayer.Dtos.EventDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminEventController : Controller
    {
        private readonly ICategoryEventService _categoryEventService;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public AdminEventController(IEventService eventService, ICategoryEventService categoryEventService, IMapper mapper)
        {
            _eventService = eventService;
            _categoryEventService = categoryEventService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultCategoryEventDto>>(await _categoryEventService.TGetListAll());

            List<SelectListItem> categoryEventList = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryColor
                                                      }).ToList();

            ViewBag.CategoryEventList = categoryEventList;

            return View();
        }

        public IActionResult CreateCategoryEvent(CreateCategoryEventDto createCategoryEventDto)
        {
            createCategoryEventDto.CategoryColor = "bg-" + createCategoryEventDto.CategoryColor;
            var createdData = _mapper.Map<CategoryEvent>(createCategoryEventDto);
            _categoryEventService.TCraete(createdData);
            if(createdData != null)
            {
                return Ok("işlem başarılı");
            }
            return NoContent();
        }

        public IActionResult CreateEvent(CreateEventDto createEventDto)
        {
            var createdData = _mapper.Map<Event>(createEventDto);
            _eventService.TCraete(createdData);

            if(createdData != null)
            {
                return Ok("işlem başarılı");
            }
            return NoContent();
        }
    }
}
