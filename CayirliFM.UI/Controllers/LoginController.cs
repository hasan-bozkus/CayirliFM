using CayirliFM.DtoLayer.Dtos.AppUserDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(CreateLoginAppUserDto createLoginAppUserDto)
        {
            AppUser user = await _userManager.FindByNameAsync(createLoginAppUserDto.EmailOrUserName);
            if (user == null)
                user = await _userManager.FindByEmailAsync(createLoginAppUserDto.EmailOrUserName);
            if (user == null)
                return View(createLoginAppUserDto);

            var result = await _signInManager.PasswordSignInAsync(user, createLoginAppUserDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminDashboard", new { areas = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı!");
            }
            return View();
        }
    }
}
