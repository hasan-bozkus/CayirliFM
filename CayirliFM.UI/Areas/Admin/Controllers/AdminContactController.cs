using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;

        public AdminContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.TContactListOrdByDescAsync();
            return View(values);
        }

        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _contactService.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ReplyToContact(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReplyToContact()
        {
            return View();
        }
    }
}
