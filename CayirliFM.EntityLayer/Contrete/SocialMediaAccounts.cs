using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class SocialMediaAccounts
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string XTwitter { get; set; }
        public string EMail { get; set; }
        public string Youtube { get; set; }
        public DateTime SocialMediaCreateAtTime { get; set; }
    }
}
