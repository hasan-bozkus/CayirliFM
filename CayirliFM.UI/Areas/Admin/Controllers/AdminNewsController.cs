using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;

        public AdminNewsController(INewsService newsService, ICategoryService categoryService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _newsService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateNews()
        {
            var values = await _categoryService.TGetListAll();
            List<SelectListItem> categoryList = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.categoryList = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult CreateNews(News news)
        {
            news.NewsCreatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsStatus = "Onay Bekliyor";
            news.EmployeeID = 1;
            _newsService.TCraete(news);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteNews(int id)
        {
            var result = await _newsService.TGetById(id);
            _newsService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNews(int id)
        {
            var result = await _newsService.TGetById(id);
            var values = await _categoryService.TGetListAll();
            List<SelectListItem> categoryList = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.categoryList = categoryList;
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateNews(News news)
        {
            news.NewsUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsStatus = "Onay Bekliyor";
            news.EmployeeID = 1;
            _newsService.TUpdate(news);
            return RedirectToAction("Index");
        }
    }
}
