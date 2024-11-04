using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        public void TCraete(Comment t)
        {
            throw new NotImplementedException();
        }
                public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
