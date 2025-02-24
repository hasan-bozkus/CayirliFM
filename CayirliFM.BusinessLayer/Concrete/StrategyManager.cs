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
    public class StrategyManager : IStrategyService
    {
        private readonly IStartegyDal _startegyDal;

        public StrategyManager(IStartegyDal startegyDal)
        {
            _startegyDal = startegyDal;
        }

        public void TCraete(Strategy t)
        {
            _startegyDal.Craete(t);
        }

        public void TDelete(Strategy t)
        {
            _startegyDal.Delete(t);
        }

        public async Task<Strategy> TGetById(int id)
        {
            return await _startegyDal.GetById(id);
        }

        public async Task<List<Strategy>> TGetListAll()
        {
            return await _startegyDal.GetListAll();
        }

        public void TUpdate(Strategy t)
        {
            _startegyDal.Update(t);
        }
    }
}
