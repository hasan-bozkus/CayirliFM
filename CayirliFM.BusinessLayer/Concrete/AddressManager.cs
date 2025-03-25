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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void TCraete(Address t)
        {
            _addressDal.Craete(t);
        }

        public void TDelete(Address t)
        {
            _addressDal.Delete(t);
        }

        public async Task<Address> TGetById(int id)
        {
            return await _addressDal.GetById(id);
        }

        public async Task<List<Address>> TGetListAll()
        {
            return await _addressDal.GetListAll();
        }

        public void TUpdate(Address t)
        {
            _addressDal.Update(t);
        }
    }
}
