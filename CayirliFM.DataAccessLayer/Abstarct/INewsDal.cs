using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
    public interface INewsDal : IGenericDal<News>
    {
        Task<List<News>> GetListNewsWithCategoryAsync();
        void ChangeNewsStatusToApproved(int id);
        void ChangeNewsStatusToNotApproved(int id);
    }
}
