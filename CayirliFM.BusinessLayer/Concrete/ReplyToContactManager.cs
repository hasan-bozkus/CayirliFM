using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DtoLayer.Dtos.ContactDtos;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class ReplyToContactManager : IReplyToContactService
    {
        private readonly IReplyToContactDal _replyToContactDal;

        public ReplyToContactManager(IReplyToContactDal replyToContactDal)
        {
            _replyToContactDal = replyToContactDal;
        }

        public void TCraete(ReplyToContact t)
        {
            _replyToContactDal.Craete(t);
        }

        public void TDelete(ReplyToContact t)
        {
            _replyToContactDal.Delete(t);
        }

        public async Task<ReplyToContact> TGetById(int id)
        {
            return await _replyToContactDal.GetById(id);
        }

        public async Task<List<ReplyToContact>> TGetListAll()
        {
            return await _replyToContactDal.GetListAll();
        }

        public async Task<ResultGetReplyToContactDto> TGetReplyToContact(int id)
        {
            return await _replyToContactDal.GetReplyToContact(id);
        }

        public async Task<List<ResultReplyToContactWithDescDto>> TGetReplyToContactsWithDesc()
        {
            return await _replyToContactDal.GetReplyToContactsWithDesc();
        }

        public async Task TReplyToContactForContactRequest(ReplyToContact replyToContact)
        {
            await _replyToContactDal.ReplyToContactForContactRequest(replyToContact);
        }

        public void TUpdate(ReplyToContact t)
        {
            _replyToContactDal.Update(t);
        }
    }
}
