using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<List<Contact>> TContactListOrdByDescAsync()
        {
            return await _contactDal.ContactListOrdByDescAsync();
        }

        public void TCraete(Contact t)
        {
            _contactDal.Craete(t);
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public async Task<Contact> TGetById(int id)
        {
            return await _contactDal.GetById(id);
        }

        public Task<List<Contact>> TGetListAll()
        {
            return _contactDal.GetListAll();
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
