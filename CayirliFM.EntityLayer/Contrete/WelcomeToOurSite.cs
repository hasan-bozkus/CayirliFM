using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class WelcomeToOurSite
    {
        [Key]
        public int WelcomeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NewsAlbumImageUrl { get; set; }
        public string NewsAlbumDescription { get; set; }
        public string WiseSaysingImageUrl { get; set; }
        public string WiseSaysingDescription { get; set; }
        public string Status { get; set; }
    }
}
