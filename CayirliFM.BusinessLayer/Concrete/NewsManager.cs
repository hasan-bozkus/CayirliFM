﻿using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {

        private readonly INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public void TCraete(News t)
        {
            _newsDal.Craete(t);
        }

        public void TDelete(News t)
        {
            _newsDal.Delete(t);
        }

        public Task<News> TGetById(int id)
        {
            return _newsDal.GetById(id);
        }

        public Task<List<News>> TGetListAll()
        {
            return _newsDal.GetListAll();
        }

        public void TUpdate(News t)
        {
            _newsDal.Update(t);
        }
    }
}
