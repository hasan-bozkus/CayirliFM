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
    public class WelcomeToOurSiteManager : IWelcomeToOurSiteService
    {
        private readonly IWelcomeToOurSiteDal _welcomeToOurSiteDal;

        public WelcomeToOurSiteManager(IWelcomeToOurSiteDal welcomeToOurSiteDal)
        {
            _welcomeToOurSiteDal = welcomeToOurSiteDal;
        }

        public void TChangeToApproved(int id)
        {
           _welcomeToOurSiteDal.ChangeToApproved(id);
        }

        public void TChangeToDeApproved(int id)
        {
           _welcomeToOurSiteDal.ChangeToDeApproved(id);
        }

        public void TCraete(WelcomeToOurSite t)
        {
            _welcomeToOurSiteDal.Craete(t);
        }

        public void TDelete(WelcomeToOurSite t)
        {
            _welcomeToOurSiteDal.Delete(t);
        }

        public async Task<WelcomeToOurSite> TGetById(int id)
        {
            return await _welcomeToOurSiteDal.GetById(id);
        }

        public async Task<List<WelcomeToOurSite>> TGetListAll()
        {
            return await _welcomeToOurSiteDal.GetListAll();
        }

        public void TUpdate(WelcomeToOurSite t)
        {
            _welcomeToOurSiteDal.Update(t);
        }
    }
}
