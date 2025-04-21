using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.SocialMediaAccountsDtos
{
    public class CreateSocialMediaAcconutDto
    {
        public string Icon { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public DateTime SocialMediaCreateAtTime { get; set; }
    }
}
