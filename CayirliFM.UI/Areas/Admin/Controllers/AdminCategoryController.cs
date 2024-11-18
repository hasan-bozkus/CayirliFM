﻿using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            category.CategoryCreatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryUpdatedAtTime = DateTime.Parse(DateTime.Now.ToString());
            category.CategoryStatus = true;
            _categoryService.TCraete(category);
            return RedirectToAction("Index");
        }
    }
}
