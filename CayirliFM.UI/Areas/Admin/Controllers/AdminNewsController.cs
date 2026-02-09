using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ICategoryService _categoryService;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<AppUser> _userManager;

        public AdminNewsController(INewsService newsService, ICategoryService categoryService, IEmployeeService employeeService, UserManager<AppUser> userManager)
        {
            _newsService = newsService;
            _categoryService = categoryService;
            _employeeService = employeeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _newsService.TGetListNewsWithCategoryAsync();
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
        public async Task<IActionResult> CreateNews(News news)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            var employeeId = await _employeeService.TGetEmployeeWithUserAsync(userId);

            news.NewsCreatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsStatus = "Onay Bekliyor";
            news.EmployeeID = employeeId.EmployeeID;
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
        public async Task<IActionResult> UpdateNews(News news)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            var employeeId = await _employeeService.TGetEmployeeWithUserAsync(userId);

            news.NewsUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            news.NewsStatus = "Onay Bekliyor";
            news.EmployeeID = employeeId.EmployeeID;
            _newsService.TUpdate(news);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeNewsStatusToApproved(int id)
        {
            _newsService.TChangeNewsStatusToApproved(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeNewsStatusToNotApproved(int id)
        {
            _newsService.TChangeNewsStatusToNotApproved(id);
            return RedirectToAction("Index");
        }
    }
}
