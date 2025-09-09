﻿using Microsoft.AspNetCore.Mvc;

namespace CayirliFM.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.isActive = "Default";
            return View();
        }

        public IActionResult WelcomePartial()
        {
            return PartialView();
        }

        public IActionResult EventPartial()
        {
            return PartialView();
        }

        public IActionResult AlbumsPartial()
        {
            return PartialView();
        }
    }
}
