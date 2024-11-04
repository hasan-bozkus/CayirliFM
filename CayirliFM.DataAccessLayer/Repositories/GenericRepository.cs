using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly Context _context;

		public GenericRepository(Context context)
		{
			_context = context;
		}

		public void Craete(T t)
		{
			_context.Add(t);
			_context.SaveChanges();
		}

		public void Delete(T t)
		{
			_context.Remove(t);
			_context.SaveChanges();
		}

		public async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetListAll()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public void Update(T t)
		{
			_context.Update(t);
			_context.SaveChanges();
		}
	}
}
