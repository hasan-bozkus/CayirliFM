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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void TCraete(Employee t)
        {
            _employeeDal.Craete(t);
        }

        public void TDelete(Employee t)
        {
            _employeeDal.Delete(t); 
        }

        public async Task<Employee> TGetById(int id)
        {
            return await _employeeDal.GetById(id);
        }

        public async Task<Employee> TGetEmployeeWithUserAsync(int appUserId)
        {
            return await _employeeDal.GetEmployeeWithUserAsync(appUserId);
        }

        public Task<List<Employee>> TGetListAll()
        {
            return _employeeDal.GetListAll();
        }

        public void TUpdate(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
