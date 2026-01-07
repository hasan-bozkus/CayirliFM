using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.AppUserDtos
{
    public class UpdateAppUserDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string EmployeeAbout { get; set; }
        public string EmployeeFacebook { get; set; }
        public string EmployeeInstagram { get; set; }
        public string EmployeeXTwitter { get; set; }
        public string EmployeeEMail { get; set; }

        public int AppUserId { get; set; }

        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
    }
}
