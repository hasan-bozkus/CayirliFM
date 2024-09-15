using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
    }
}
