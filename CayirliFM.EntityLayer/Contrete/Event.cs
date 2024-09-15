using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public DateTime EventTime { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Status { get; set; }
    }
}
