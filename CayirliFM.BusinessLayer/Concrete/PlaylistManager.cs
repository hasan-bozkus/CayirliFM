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
    public class PlaylistManager : IPlaylistService
    {
        private readonly IPlaylistDal _playlistDal;

        public PlaylistManager(IPlaylistDal playlistDal)
        {
            _playlistDal = playlistDal;
        }

        public void TCraete(Playlist t)
        {
            _playlistDal.Craete(t);
        }

        public void TDelete(Playlist t)
        {
            _playlistDal.Delete(t);
        }

        public async Task<Playlist> TGetById(int id)
        {
            return await _playlistDal.GetById(id);
        }

        public async Task<List<Playlist>> TGetListAll()
        {
            return await _playlistDal.GetListAll();
        }

        public void TUpdate(Playlist t)
        {
            _playlistDal.Update(t);
        }
    }
}
