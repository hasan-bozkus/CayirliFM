using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.AppUserDtos
{
    public class CreateRegisterAppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeAbout { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
        public bool OurTeam { get; set; }
        public string Status { get; set; }
        public int AppUserId { get; set; }
    }
}
