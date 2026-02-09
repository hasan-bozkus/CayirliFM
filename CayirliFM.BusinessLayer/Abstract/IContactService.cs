using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        Task<List<Contact>> TContactListOrdByDescAsync();
        Task<int> TGetContactCountAsync();
    }
}
