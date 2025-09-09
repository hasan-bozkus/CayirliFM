using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
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
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TCraete(Comment t)
        {
            _commentDal.Craete(t);
        }
        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public async Task<Comment> TGetById(int id)
        {
            return await _commentDal.GetById(id);
                 
        }

        public async Task<List<Comment>> TGetCommentListByBlogId(int id)
        {
            return await _commentDal.GetCommentListByBlogId(id);
        }

        public Task<List<Comment>> TGetListAll()
        {
            return _commentDal.GetListAll();
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
