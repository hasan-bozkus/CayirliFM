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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TCraete(About t)
        {
            _aboutDal.Craete(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public async Task<About> TGetById(int id)
        {
            return await _aboutDal.GetById(id);
        }

        public async Task<List<About>> TGetListAll()
        {
            return await _aboutDal.GetListAll();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
