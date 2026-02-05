using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class Playlist
    {
        [Key]
        public int PlaylistID { get; set; }
        public string PlaylistName { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
