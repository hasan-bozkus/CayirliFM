using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Abstract
{
    public interface INewsService : IGenericService<News>
    {
        Task<List<News>> TGetListNewsWithCategoryAsync();
        void TChangeNewsStatusToApproved(int id);
        void TChangeNewsStatusToNotApproved(int id);
        Task<List<News>> TGetLast4NewsWithApproved();
    }
}
