using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class EventManager : IEventService
    {
        public void TCraete(Event t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Event t)
        {
            throw new NotImplementedException();
        }
    }
}
