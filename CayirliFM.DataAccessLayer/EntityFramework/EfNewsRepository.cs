﻿using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfNewsRepository : GenericRepository<News>, INewsDal
    {
        public EfNewsRepository(Context context) : base(context)
        {
        }
    }
}
