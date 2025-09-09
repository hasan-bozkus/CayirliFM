using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactCreateAtTime { get; set; }
        public bool Status { get; set; }
    }
}
