using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Admin.AdminEvent
{
    public class _AdminEventListOfEvent : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public _AdminEventListOfEvent(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultEventDto>>(await _eventService.TGetListAll());
            return View(values);
        }
    }
}
