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
    public class EfStrategyRepository : GenericRepository<Strategy>, IStartegyDal
    {
        public EfStrategyRepository(Context context) : base(context)
        {
        }

        public async Task ChangeToFalseWithStrategy(int id)
        {
            using (var context = new Context())
            {
                var result = await context.Strategies.FindAsync(id);
                result.StrategyStatus = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task ChangeToTrueWithStrategy(int id)
        {
            using (var context = new Context())
            {
                var result = await context.Strategies.FindAsync(id);
                result.StrategyStatus = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Strategy>> GetStrategyListWithStatusTrue()
        {
            using(var context = new Context())
            {
                var values = await context.Strategies.Where(x => x.StrategyStatus == true).ToListAsync();
                return values;
            }
        }
    }
}
