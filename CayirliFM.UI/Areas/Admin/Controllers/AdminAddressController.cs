using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.AddressDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AdminAddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultAddressDto>>(await _addressService.TGetListAll());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAdress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdress(CreateAddressDto createAddressDto)
        {
            var result = _mapper.Map<Address>(createAddressDto);
            _addressService.TCraete(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAdress(int id)
        {
            var result = await _addressService.TGetById(id);
            _addressService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var result = _mapper.Map<UpdateAddressDto>(await _addressService.TGetById(id));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            var result = _mapper.Map<Address>(updateAddressDto);
            _addressService.TUpdate(result);
            return RedirectToAction("Index");
        }

    }
}
