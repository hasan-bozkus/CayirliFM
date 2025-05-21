using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
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
        private readonly IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void TCraete(Event t)
        {
            _eventDal.Craete(t);
        }

        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
        }

        public async Task<Event> TGetById(int id)
        {
            return await _eventDal.GetById(id);
        }

        public async Task<List<Event>> TGetListAll()
        {
            return await _eventDal.GetListAll();
        }

        public void TUpdate(Event t)
        {
            _eventDal.Update(t);
        }
    }
}
