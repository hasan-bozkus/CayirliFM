﻿using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Abstract
{
    public interface IStrategyService : IGenericService<Strategy>
    {
        Task TChangeToTrueWithStrategy(int id);
        Task TChangeToFalseWithStrategy(int id);
    }
}
