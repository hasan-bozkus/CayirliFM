using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.AddressDtos
{
    public class ResultGetAddressByIdDto
    {
        public int AddressID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
    }
}
