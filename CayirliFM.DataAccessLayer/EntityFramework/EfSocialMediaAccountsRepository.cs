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
    public class EfSocialMediaAccountsRepository : GenericRepository<SocialMediaAccounts>, ISocialMediaAccountsDal
    {
        public EfSocialMediaAccountsRepository(Context context) : base(context)
        {
        }
    }
}