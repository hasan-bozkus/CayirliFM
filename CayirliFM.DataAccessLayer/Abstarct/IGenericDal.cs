using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
	public interface IGenericDal<T> where T : class
	{
		void Craete(T t);
		void Update(T t);
		void Delete(int id);
		Task<List<T>> GetListAll();
		Task<T> GetById(int id);
	}
}
