using CayirliFM.DtoLayer.Dtos.HiggingFaceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.External
{
    public interface IHuggingFaceService
    {
        Task<string> TranslationEnglishAsync(string turkishText);
        Task<ToxicityDedectionResultDto> DetectionToxicityAsync(string commentText);
    }
}
