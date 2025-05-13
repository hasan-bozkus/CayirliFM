using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfWelcomeToOurSiteRepository : GenericRepository<WelcomeToOurSite>, IWelcomeToOurSiteDal
    {
        public EfWelcomeToOurSiteRepository(Context context) : base(context)
        {
        }

        public void ChangeToApproved(int id)
        {
            using(var context = new Context())
            {
                var values = context.WelcomeToOurSites.Find(id);
                values.Status = "Onaylandı";
                context.Update(values);
                context.SaveChanges();
            }
        }

        public void ChangeToDeApproved(int id)
        {
            using (var context = new Context())
            {
                var values = context.WelcomeToOurSites.Find(id);
                values.Status = "Onaylanmadı";
                context.Update(values);
                context.SaveChanges();
            }
        }
    }
}
