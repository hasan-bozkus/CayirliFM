using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CayirliFM.EntityLayer.Contrete;
using CayirliFM.DtoLayer.Dtos.ContactDtos;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IReplyToContactService _replyToContactService;
        private readonly IMapper _mapper;

        public AdminContactController(IContactService contactService, IReplyToContactService replyToContactService, IMapper mapper)
        {
            _contactService = contactService;
            _replyToContactService = replyToContactService;
            _mapper = mapper;
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

        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.TGetById(id);
            _contactService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ReplyToContact(int id)
        {
            var values = await _contactService.TGetById(id);
            ViewBag.ReceiverEmail = values.EMail;
            ViewBag.Subject = values.ContactSubject;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReplyToContact(CreateReplyToContactDto createReplyToContactDto)
        {
            createReplyToContactDto.SendingDate = DateTime.Parse(DateTime.Now.ToString());
            var result = _mapper.Map<ReplyToContact>(createReplyToContactDto);
            await _replyToContactService.TReplyToContactForContactRequest(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetReplyToContacts()
        {
            var values = await _replyToContactService.TGetReplyToContactsWithDesc();
            return View(values);
        }

        public async Task<IActionResult> GetReplyToContact(int id)
        {
            var value = await _replyToContactService.TGetReplyToContact(id);
            return View(value);
        }
    }
}
