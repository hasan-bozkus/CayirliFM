using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Abstarct
{
    public interface IMusicDal : IGenericDal<Music>
    {
        Task<List<Music>> GetMusicListByPlaylistID(int id);
        Task<List<Music>> GetMusicListByPlaylistIDDesc(int id);
    }
}
