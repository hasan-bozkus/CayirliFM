using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.EntityLayer.Contrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.BusinessLayer.Concrete
{
    public class MusicManager : IMusicService
    {
        private readonly IMusicDal _musicDal;

        public MusicManager(IMusicDal musicDal)
        {
            _musicDal = musicDal;
        }

        public void TCraete(Music t)
        {
            _musicDal.Craete(t);
        }

        public void TDelete(Music t)
        {
            _musicDal.Delete(t);
        }

        public async Task<Music> TGetById(int id)
        {
            return await _musicDal.GetById(id);
        }

        public async Task<List<Music>> TGetListAll()
        {
            return await _musicDal.GetListAll();
        }

        public async Task<List<Music>> TGetMusicListByPlaylistID(int id)
        {
            return await _musicDal.GetMusicListByPlaylistID(id);    
        }

        public async Task<List<Music>> TGetMusicListByPlaylistIDDesc(int id)
        {
            return await _musicDal.GetMusicListByPlaylistIDDesc(id);
        }

        public void TUpdate(Music t)
        {
            _musicDal.Update(t);
        }
    }
}
