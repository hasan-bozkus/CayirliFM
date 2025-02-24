using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.StrategyDtos
{
    public class ResultGetStrategyByIDDto
    {
        public int StrategyID { get; set; }
        public string StrategyTitle { get; set; }
        public string StrategyValue { get; set; }
        public bool StrategyStatus { get; set; }
    }
}
