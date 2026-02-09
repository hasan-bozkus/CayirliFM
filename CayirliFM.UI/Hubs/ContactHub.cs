using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace CayirliFM.UI.Hubs
{
    public class ContactHub : Hub
    {
        private readonly IContactService _contactService;
        private readonly IReplyToContactService _replyToContactService;

        public ContactHub(IContactService contactService, IReplyToContactService replyToContactService)
        {
            _contactService = contactService;
            _replyToContactService = replyToContactService;
        }

        public async Task ContactProcess()
        {
            var getContactRequestCount = await _contactService.TGetContactCountAsync();
            await Clients.All.SendAsync("GetContactRequestCount", getContactRequestCount);

            var getReplyToContactCount = await _replyToContactService.TGetReplyToContactCountAsync();
            await Clients.All.SendAsync("GetReplyToContactCount", getReplyToContactCount);
        }
    }
}
