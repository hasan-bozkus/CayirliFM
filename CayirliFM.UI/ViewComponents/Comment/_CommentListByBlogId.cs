using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.ViewComponents.Comment
{
    public class _CommentListByBlogId : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByBlogId(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.id = id;
            var values = await _commentService.TGetCommentListByBlogId(id);
            return View(values);
        }
    }
}
