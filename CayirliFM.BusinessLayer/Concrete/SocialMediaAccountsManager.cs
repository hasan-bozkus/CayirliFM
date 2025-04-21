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
    public class SocialMediaAccountsManager : ISocialMediaAccountsService
    {
        private readonly ISocialMediaAccountsDal _socialMediaAccountsDal;

        public SocialMediaAccountsManager(ISocialMediaAccountsDal socialMediaAccountsDal)
        {
            _socialMediaAccountsDal = socialMediaAccountsDal;
        }

        public void TCraete(SocialMediaAccounts t)
        {
            _socialMediaAccountsDal.Craete(t);
        }

        public void TDelete(SocialMediaAccounts t)
        {
           _socialMediaAccountsDal.Delete(t);
        }

        public async Task<SocialMediaAccounts> TGetById(int id)
        {
            return await _socialMediaAccountsDal.GetById(id);
        }

        public async Task<List<SocialMediaAccounts>> TGetListAll()
        {
            return await _socialMediaAccountsDal.GetListAll();
        }

        public void TUpdate(SocialMediaAccounts t)
        {
            _socialMediaAccountsDal.Update(t);
        }
    }
}
