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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TCraete(Category t)
        {
            _categoryDal.Craete(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public async Task<Category> TGetById(int id)
        {
            return await _categoryDal.GetById(id);
        }

        public async Task<List<Category>> TGetListAll()
        {
            return await _categoryDal.GetListAll();
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
