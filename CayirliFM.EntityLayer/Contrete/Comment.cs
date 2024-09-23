using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Message { get; set; }
        public DateTime CommentCreateAtTime { get; set; }
        public bool Status { get; set; }

        public int NewsID { get; set; }
        public News News { get; set; }
    }
}
