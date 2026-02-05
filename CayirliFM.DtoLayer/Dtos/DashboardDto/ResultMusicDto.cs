using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.DashboardDto
{
    public class ResultMusicDto
    {
        public int MusicID { get; set; }
        public string MusicName { get; set; }
        public string MusicPath { get; set; }
        public int PlaylistID { get; set; }
    }
}
