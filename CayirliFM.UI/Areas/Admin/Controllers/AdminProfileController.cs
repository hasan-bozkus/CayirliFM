using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.AppUserDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmployeeService _employeeService;

        public AdminProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            var employeeWithAppUser = await _employeeService.TGetEmployeeWithUserAsync(userId);

            var result = new UpdateAppUserDto
            {
                AppUserId = employeeWithAppUser.AppUserId,
                EMail = employeeWithAppUser.EMail,
                EmployeeAbout = employeeWithAppUser.EmployeeAbout,
                EmployeeEMail = employeeWithAppUser.EmployeeEMail,
                EmployeeFacebook = employeeWithAppUser.EmployeeFacebook,
                EmployeeID = employeeWithAppUser.EmployeeID,
                EmployeeInstagram = employeeWithAppUser.EmployeeInstagram,
                EmployeeXTwitter = employeeWithAppUser.EmployeeXTwitter,
                Name = employeeWithAppUser.Name,
                Surname = employeeWithAppUser.Surname,
                UserName = employeeWithAppUser.AppUser.UserName,
                Phone = employeeWithAppUser.Phone
            };
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UserProfile(UpdateAppUserDto updateAppUserDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEmail = updateAppUserDto.EMail;

            var employee = await _employeeService.TGetById(updateAppUserDto.EmployeeID);

            employee.AppUserId = updateAppUserDto.AppUserId;
            employee.EmployeeID = updateAppUserDto.EmployeeID;
            employee.EMail = updateAppUserDto.EMail;
            employee.Phone = updateAppUserDto.Phone;
            employee.EmployeeAbout = updateAppUserDto.EmployeeAbout;
            employee.EmployeeEMail = updateAppUserDto.EmployeeEMail;
            employee.EmployeeFacebook = updateAppUserDto.EmployeeFacebook;
            employee.EmployeeXTwitter = updateAppUserDto.EmployeeXTwitter;
            employee.EmployeeInstagram = updateAppUserDto.EmployeeInstagram;
            employee.Name = user.Name;
            employee.Surname = user.Surname;

            if (updateAppUserDto.PasswordHash != null)
            {
                if (updateAppUserDto.PasswordHash == updateAppUserDto.ConfirmPasswordHash)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, updateAppUserDto.PasswordHash);
                }
            }

            var result = await _userManager.UpdateAsync(user);

            _employeeService.TUpdate(employee);

            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("LoginUser", "Login", new { area = "" });
            }

            return View();
        }
    }
}
