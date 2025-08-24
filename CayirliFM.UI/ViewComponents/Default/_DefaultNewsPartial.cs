using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.NewsDtos;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Default
{
    public class _DefaultNewsPartial : ViewComponent
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;

        public _DefaultNewsPartial(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _mapper.Map<List<ResultLast4NewsDto>>(await _newsService.TGetLast4NewsWithApproved());

            return View(values);
        }
    }
}
