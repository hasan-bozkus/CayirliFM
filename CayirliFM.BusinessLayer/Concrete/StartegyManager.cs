using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class StartegyManager : IStrategyService
    {
        public void TCraete(Strategy t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Strategy> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Strategy>> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Strategy t)
        {
            throw new NotImplementedException();
        }
    }
}
