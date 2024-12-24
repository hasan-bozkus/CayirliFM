using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int? EmployeeID { get; set; }
        public Employee ? Employee { get; set; }

        public ICollection<Comment> ? Comments { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

    }
}
