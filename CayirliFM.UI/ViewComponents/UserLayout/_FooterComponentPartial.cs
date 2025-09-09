using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.ViewComponents.UserLayout
{
    public class _FooterComponentPartial : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _FooterComponentPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _addressService.TGetById(2);
            return View(values);
        }
    }
}
