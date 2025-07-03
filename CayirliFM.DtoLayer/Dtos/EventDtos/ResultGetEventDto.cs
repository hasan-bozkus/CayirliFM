using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.EventDtos
{
    public class ResultGetEventDto
    {
        public int EventID { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTitle { get; set; }
        public string EventColor { get; set; }
        public bool Status { get; set; }
    }
}
