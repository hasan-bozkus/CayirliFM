using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeAbout { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeFacebook { get; set; }
        public string EmployeeInstagram { get; set; }
        public string EmployeeXTwitter { get; set; }
        public string EmployeeEMail { get; set; }
        public bool OurTeam {  get; set; }
        public string Status { get; set; }
    }
}
