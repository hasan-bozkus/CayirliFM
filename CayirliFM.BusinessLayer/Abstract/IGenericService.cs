using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TCraete(T t);
        void TUpdate(T t);
        void TDelete(int id);
        Task<List<T>> TGetListAll();
        Task<T> TGetById(int id);
    }
}
