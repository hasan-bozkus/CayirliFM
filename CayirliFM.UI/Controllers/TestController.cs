using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly ICategoryService _categoryService;

        public TestController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTest(Category category)
        {
            category.CategoryCreatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryStatus = true;
            _categoryService.TCraete(category);
            return RedirectToAction("Index");
        }
    }
}
