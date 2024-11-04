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

        public async Task<IActionResult> DeleteTest(int id)
        {
            var result = await _categoryService.TGetById(id);
            _categoryService.TDelete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTest(int id)
        {
            var result = await _categoryService.TGetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateTest(Category category)
        {
            category.CategoryUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryCreatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryStatus = true;
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
