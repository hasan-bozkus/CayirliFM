using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.HiggingFaceDto
{
    public class ToxicityDedectionResultDto
    {
        public bool IsToxic { get; set; }
        public double Score { get; set; }
        public string DetectLabel { get; set; }
    }
}
