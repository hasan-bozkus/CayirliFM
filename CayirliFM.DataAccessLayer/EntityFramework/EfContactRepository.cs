using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfContactRepository : GenericRepository<Contact>, IContactDal
    {
        public EfContactRepository(Context context) : base(context)
        {
        }

        public async Task<List<Contact>> ContactListOrdByDescAsync()
        {
            using (var context = new Context())
            {
                var values = await context.Contacts.OrderByDescending(x => x.ContactID).ToListAsync();
                return values;
            }
        }
    }
}
