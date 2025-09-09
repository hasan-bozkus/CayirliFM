using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            ViewBag.isActive = "Contact";

            contact.Status = false;
            contact.ContactCreateAtTime = DateTime.Now;

            _contactService.TCraete(contact);
            return RedirectToAction("Index");
        }
    }
}
