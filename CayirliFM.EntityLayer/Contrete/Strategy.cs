using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Strategy
    {
        [Key]
        public int StrategyID { get; set; }
        public string StrategyTitle { get; set; }
        public string StrategyValue { get; set; }
        public bool StrategyStatus { get; set; }
    }
}
