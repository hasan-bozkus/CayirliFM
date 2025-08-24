using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Default
{
    public class _DefaultEventsPartial : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public _DefaultEventsPartial(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultEventDto>>(await _eventService.TUpcomingEventsAsync());
            return View(values);
        }
    }
}
