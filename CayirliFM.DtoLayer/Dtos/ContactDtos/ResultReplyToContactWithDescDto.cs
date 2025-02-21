using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.ContactDtos
{
    public class ResultReplyToContactWithDescDto
    {
        public int ReplyToContactID { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendingDate { get; set; }
    }
}
