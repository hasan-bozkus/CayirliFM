using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DtoLayer.Dtos.DashboardDto
{
    public class UploadMusicDto
    {
        public List<IFormFile> Url { get; set; }
        public int PlaylistID { get; set; }
    }
}
