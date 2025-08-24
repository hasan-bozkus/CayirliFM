using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfNewsRepository : GenericRepository<News>, INewsDal
    {
        public EfNewsRepository(Context context) : base(context)
        {
        }

        public void ChangeNewsStatusToApproved(int id)
        {
            using (var context = new Context())
            {
                var result = context.News.Find(id);
                result.NewsStatus = "Onaylandı";
                context.Update(result);
                context.SaveChanges();
            }
        }

        public void ChangeNewsStatusToNotApproved(int id)
        {
            using (var context = new Context())
            {
                var result = context.News.Find(id);
                result.NewsStatus = "Onaylanmadı";
                context.Update(result);
                context.SaveChanges();
            }
        }

        public async Task<List<News>> GetLast4NewsWithApproved()
        {
            using (var context = new Context())
            {
                var values = await context.News.Where(x => x.NewsStatus == "Onaylandı").OrderByDescending(y => y.NewsID).Take(4).ToListAsync();

                return values;
            }
        }

        public async Task<List<News>> GetListNewsWithCategoryAsync()
        {
            using(var context = new Context())
            {
                var values = await context.News.Include(x => x.Category).Select(y => new News
                {
                    CategoryID = y.CategoryID,
                    NewsID = y.NewsID,
                    NewsTitle = y.NewsTitle,
                    NewsSubDescrpition = y.NewsSubDescrpition,
                    NewsCreatedAtTime = y.NewsCreatedAtTime,
                    NewsUpdatedAtTime = y.NewsUpdatedAtTime,
                    NewsStatus = y.NewsStatus,
                    CategoryName = y.Category.CategoryName
                }).ToListAsync();

                return values;
            }
        }
    }
}
