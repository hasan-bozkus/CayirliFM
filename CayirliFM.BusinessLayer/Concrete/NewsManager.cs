using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {
        public void TCraete(News t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<News> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<News>> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(News t)
        {
            throw new NotImplementedException();
        }
    }
}
