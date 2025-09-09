using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Contact
{
    public class _ContactLeftAndMap : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _ContactLeftAndMap(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _addressService.TGetById(2);
            return View(value);
        }
    }
}
