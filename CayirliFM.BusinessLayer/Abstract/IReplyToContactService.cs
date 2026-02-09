using CayirliFM.DtoLayer.Dtos.ContactDtos;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Abstract
{
    public interface IReplyToContactService : IGenericService<ReplyToContact>
    {
        Task TReplyToContactForContactRequest(ReplyToContact replyToContact);
        Task<List<ResultReplyToContactWithDescDto>> TGetReplyToContactsWithDesc();
        Task<ResultGetReplyToContactDto> TGetReplyToContact(int id);
        Task<int> TGetReplyToContactCountAsync();
    }
}
