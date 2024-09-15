using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsSubDescrpition { get; set; }
        public string NewsSubImage { get; set; }
        public string NewsImage { get; set; }
        public DateTime NewsCreatedAtTime { get; set; }
        public DateTime NewsUpdatedAtTime { get; set; }
        public string NewsStatus { get; set; }

    }
}
