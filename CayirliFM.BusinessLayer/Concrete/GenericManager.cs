using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TCraete(T t)
        {
            _genericDal.Craete(t);
        }

        public void TDelete(T t)
        {
            _genericDal.Delete(t);
        }

        public Task<T> TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public Task<List<T>> TGetListAll()
        {
            return _genericDal.GetListAll();
        }

        public void TUpdate(T t)
        {
            _genericDal.Update(t);
        }
    }
}
