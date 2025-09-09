using CayirliFM.BusinessLayer.Abstract;
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

        public BlogController(INewsService newsService, ICommentService commentService)
        {
            _newsService = newsService;
            _commentService = commentService;
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
        public IActionResult CreateComment(Comment comment)
        {
            comment.CommentCreateAtTime = DateTime.Now;
            comment.Status = false;
            _commentService.TCraete(comment);
            return RedirectToAction("NewsReadAll", "Blog", new {id = comment.NewsID });
        }
	}
}
