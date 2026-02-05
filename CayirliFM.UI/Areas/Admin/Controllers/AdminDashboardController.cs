using AutoMapper;
using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.DashboardDto;
using CayirliFM.EntityLayer.Contrete;
using CayirliFM.UI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        private readonly IHubContext<MusicHub> _contextHub;

        public AdminDashboardController(IPlaylistService playlistService, IMusicService musicService, IMapper mapper, IHubContext<MusicHub> contextHub)
        {
            _playlistService = playlistService;
            _musicService = musicService;
            _mapper = mapper;
            _contextHub = contextHub;
        }

        public async Task<IActionResult> Index()
        {
            var values = _mapper.Map<List<ResultPlaylistDto>>(await _playlistService.TGetListAll());

            List<SelectListItem> playlistItems = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.PlaylistName,
                                                      Value = x.PlaylistID.ToString()
                                                  }).ToList();

            ViewBag.playlistItems = playlistItems;
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePlaylist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlaylist(CreatePlaylistDto createPlaylistDto)
        {
            var mapper = _mapper.Map<Playlist>(createPlaylistDto);
            _playlistService.TCraete(mapper);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GoToPlaylist(int id)
        {
            var values = _mapper.Map<List<ResultMusicDto>>(await _musicService.TGetMusicListByPlaylistID(id));

            if (values == null || !values.Any())
            {
                return NotFound("Bu çalma listesinde müzik bulunamadı.");
            }
            var jsonData = JsonConvert.SerializeObject(values);
            return Json(values);
        }

        public async Task<IActionResult> UploadMusic(UploadMusicDto uploadMusicDto)
        {
            if (uploadMusicDto.Url == null || uploadMusicDto.Url.Count == 0)
            {
                return BadRequest("Lütfen en az bir müzik dosyası seçiniz.");
            }

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/music");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var uploadedFiles = new List<object>();

            foreach (var file in uploadMusicDto.Url)
            {
                string uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var music = new Music
                {
                    MusicName = Path.GetFileNameWithoutExtension(file.FileName),
                    MusicPath = "/music/" + uniqueFileName,
                    PlaylistID = uploadMusicDto.PlaylistID
                };

                uploadedFiles.Add(new { title = music.MusicName, url = music.MusicPath });

                _musicService.TCraete(music);

            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> StartBroadcast(int id)
        {
            var songs = await _musicService.TGetMusicListByPlaylistID(id);

            if(!songs.Any())
            {
                return BadRequest("Oynatma Listesinde Müzik Bulunamadı.");
            }

            await _contextHub.Clients.All.SendAsync("PlaySong", songs[0].MusicPath);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> StopBroadcast()
        {
            await _contextHub.Clients.All.SendAsync("StopSong");
            return Ok();
        }
    }
}
