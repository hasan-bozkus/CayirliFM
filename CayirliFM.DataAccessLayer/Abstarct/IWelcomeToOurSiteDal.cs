using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
    public interface IWelcomeToOurSiteDal : IGenericDal<WelcomeToOurSite>
    {
        void ChangeToApproved(int id);
        void ChangeToDeApproved(int id);
    }
}
