using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.CategoryEventDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Admin.AdminEvent
{
    public class _AdminEventCategoryList : ViewComponent
    {
        private readonly ICategoryEventService _categoryEventService;
        private readonly IMapper _mapper;

        public _AdminEventCategoryList(ICategoryEventService categoryEventService, IMapper mapper)
        {
            _categoryEventService = categoryEventService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultCategoryEventDto>>(await _categoryEventService.TGetListAll());
            return View();
        }
    }
}
