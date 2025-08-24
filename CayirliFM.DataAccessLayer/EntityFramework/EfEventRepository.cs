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
    public class EfEventRepository : GenericRepository<Event>, IEventDal
    {
        private readonly Context _context;

        public EfEventRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Event>> UpcomingEventsAsync()
        {
            var today = DateTime.Today;

            var values = await _context.Events.Where(x => x.EventStartDate >= today).Take(2).ToListAsync();
            return values;
        }
    }
}
