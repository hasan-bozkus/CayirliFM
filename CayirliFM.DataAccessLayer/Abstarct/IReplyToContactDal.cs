﻿using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
    public interface IReplyToContactDal : IGenericDal<ReplyToContact>
    {
        Task ReplyToContactForContactRequest(ReplyToContact replyToContact);
    }
}
