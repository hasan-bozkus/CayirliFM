using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.About
{
    public class _AboutUpcomignLast4EventDetail : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public _AboutUpcomignLast4EventDetail(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultGetLast4EventsDto>>(await _eventService.TUpcomingLast4EventsAsync());
            return View(values);
        }
    }
}
