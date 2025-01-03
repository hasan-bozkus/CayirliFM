﻿using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
    public interface IContactDal : IGenericDal<Contact>
    {
        Task<List<Contact>> ContactListOrdByDescAsync();
    }
}
