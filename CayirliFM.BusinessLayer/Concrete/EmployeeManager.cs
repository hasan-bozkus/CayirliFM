using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        public void TCraete(Employee t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
