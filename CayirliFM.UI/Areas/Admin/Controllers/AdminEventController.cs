using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.CategoryEventDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCategoryEvent(CreateCategoryEventDto createCategoryEventDto)
        {
            var createdData = _mapper.Map<CategoryEvent>(createCategoryEventDto);
            _categoryEventService.TCraete(createdData);
            if(createdData != null)
            {
                return Ok("işlem başarılı");
            }
            return NoContent();
        }
    }
}
