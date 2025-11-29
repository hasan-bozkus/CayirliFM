using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.BusinessLayer.External;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

namespace CayirliFM.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ICommentService _commentService;
        private readonly IHuggingFaceService _huggingFaceService;

        public BlogController(INewsService newsService, ICommentService commentService, IHuggingFaceService huggingFaceService)
        {
            _newsService = newsService;
            _commentService = commentService;
            _huggingFaceService = huggingFaceService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.isActive = "Blog";

            var values = await _newsService.TGetListAll();
            return View(values.ToPagedList(page, 6));
        }

        public async Task<IActionResult> NewsReadAll(int id)
        {
            ViewBag.id = id;
            var values = await _newsService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {

            try
            {
                if (comment == null || string.IsNullOrWhiteSpace(comment.Message))
                {
                    TempData["ModalMessage"] = "Yorumunuz boş olamaz!";
                    TempData["ModalStatus"] = "Error";
                    return RedirectToAction("NewsReadAll", "Blog", new { id = comment.NewsID });
                }

                comment.CommentCreateAtTime = DateTime.Now;
                comment.Status = false;
                var transladetText = await _huggingFaceService.TranslationEnglishAsync(comment.Message);
                var toxicityResult = await _huggingFaceService.DetectionToxicityAsync(transladetText);
                comment.IsToxic = toxicityResult.IsToxic;
                comment.ToxicityScore = toxicityResult.Score.ToString();

                if (comment.IsToxic)
                {
                    TempData["ModalMessage"] = "Yorumunuz uygunsuz içerik barındırdığı için yayınlanmamıştır.";
                    TempData["ModalStatus"] = "Error";
                    return RedirectToAction("NewsReadAll", "Blog", new { id = comment.NewsID });
                }

                TempData["ModalMessage"] = "Yorumuzun başarıyla eklendi";
                TempData["ModalStatus"] = "Success";
                _commentService.TCraete(comment);
                return RedirectToAction("NewsReadAll", "Blog", new { id = comment.NewsID });

            }
            catch (Exception)
            {
                return RedirectToAction("NewsReadAll", "Blog", new { id = comment.NewsID });
                throw;
            }

        }
    }
}
