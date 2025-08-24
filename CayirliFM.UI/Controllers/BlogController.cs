using CayirliFM.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

namespace CayirliFM.UI.Controllers
{
	public class BlogController : Controller
	{

		private readonly INewsService _newsService;

        public BlogController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1)
		{
			var values = await _newsService.TGetListAll();
			return View(values.ToPagedList(page, 6));
		}
	}
}
