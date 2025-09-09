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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        private readonly Context _context;

        public EfCommentRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentListByBlogId(int id)
        {
            var values = await _context.Comments.Where(y => y.NewsID == id).ToListAsync();
            return values;
        }
    }
}
