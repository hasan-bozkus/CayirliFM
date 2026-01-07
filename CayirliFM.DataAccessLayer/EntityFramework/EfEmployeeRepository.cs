using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfEmployeeRepository : GenericRepository<Employee>, IEmployeeDal
    {
        private readonly Context _context;

        public EfEmployeeRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeWithUserAsync(int appUserId)
        {
            var value = await (from e in _context.Employees
                               join u in _context.Users
                               on e.AppUserId equals u.Id
                               where u.Id == appUserId
                               select new Employee
                               {
                                   AppUserId = e.AppUserId,
                                   EmployeeID = e.EmployeeID,
                                   EMail = e.EMail,
                                   EmployeeAbout = e.EmployeeAbout,
                                   EmployeeEMail = e.EmployeeEMail,
                                   EmployeeFacebook = e.EmployeeFacebook,
                                   EmployeeInstagram = e.EmployeeInstagram,
                                   EmployeeXTwitter = e.EmployeeXTwitter,
                                   Phone = e.Phone,
                                   AppUser = u
                               }).FirstOrDefaultAsync();
            return value;
        }
    }
}
