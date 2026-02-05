using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Music
    {
        [Key]
        public int MusicID { get; set; }
        public string MusicName { get; set; }
        public string MusicPath { get; set; }
        public int PlaylistID { get; set; }
        public Playlist Playlist { get; set; }
    }
}
