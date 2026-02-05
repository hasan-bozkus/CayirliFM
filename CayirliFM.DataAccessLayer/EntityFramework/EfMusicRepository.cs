using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.EntityFramework
{
    public class EfMusicRepository : GenericRepository<Music>, IMusicDal
    {
        private readonly Context _context;

        public EfMusicRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Music>> GetMusicListByPlaylistID(int id)
        {
            var values = await _context.Musics.Where(x => x.PlaylistID == id).ToListAsync();
            return values;
        }

        public async Task<List<Music>> GetMusicListByPlaylistIDDesc(int id)
        {
            var values = await _context.Musics.Where(x => x.PlaylistID == id).OrderByDescending(y => y.MusicID).ToListAsync();
            return values;
        }
    }
}
