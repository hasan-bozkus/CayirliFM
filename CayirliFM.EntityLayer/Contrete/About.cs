using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutVideoUrl { get; set; }
    }
}
