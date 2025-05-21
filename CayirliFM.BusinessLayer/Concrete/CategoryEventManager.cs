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
    public class CategoryEventManager : ICategoryEventService
    {
        private readonly ICategoryEventDal _categoryEventDal;

        public CategoryEventManager(ICategoryEventDal categoryEventDal)
        {
            _categoryEventDal = categoryEventDal;
        }

        public void TCraete(CategoryEvent t)
        {
            _categoryEventDal.Craete(t);
        }

        public void TDelete(CategoryEvent t)
        {
            _categoryEventDal.Delete(t);
        }

        public async Task<CategoryEvent> TGetById(int id)
        {
            return await _categoryEventDal.GetById(id);
        }

        public async Task<List<CategoryEvent>> TGetListAll()
        {
            return await _categoryEventDal.GetListAll();
        }

        public void TUpdate(CategoryEvent t)
        {
            _categoryEventDal.Update(t);
        }
    }
}
