using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.DtoLayer.Dtos.AppUserDtos;
using CayirliFM.EntityLayer.Contrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CayirliFM.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class PersonalProccessController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IEmployeeService _employeeService;

        public PersonalProccessController(UserManager<AppUser> userManager, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult AddPersonal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonal(CreateRegisterAppUserDto createRegisterAppUserDto)
        {
            if (createRegisterAppUserDto.PasswordHash == createRegisterAppUserDto.ConfirmPasswordHash)
            {
                var appUser = new AppUser()
                {
                    Name = createRegisterAppUserDto.Name,
                    Surname = createRegisterAppUserDto.Surname,
                    UserName = createRegisterAppUserDto.UserName,
                    Email = createRegisterAppUserDto.EMail,
                    PhoneNumber = createRegisterAppUserDto.Phone
                };

                var result = await _userManager.CreateAsync(appUser, createRegisterAppUserDto.PasswordHash);

                if (result.Succeeded)
                {
                    var employee = new Employee()
                    {
                        Name = appUser.Name,
                        Surname = appUser.Surname,
                        Phone = appUser.PhoneNumber,
                        EmployeeDepartment = createRegisterAppUserDto.EmployeeDepartment,
                        EmployeeAbout = createRegisterAppUserDto.EmployeeAbout,
                        OurTeam = createRegisterAppUserDto.OurTeam,
                        Status = createRegisterAppUserDto.Status,
                        AppUserId = appUser.Id,
                        EMail = createRegisterAppUserDto.EMail,
                        EmployeeEMail = "Değer Yok",
                        EmployeeFacebook = "Değer Yok",
                        EmployeeInstagram = "Değer Yok",
                        EmployeeXTwitter = "Değer Yok"
                    };

                    _employeeService.TCraete(employee);
                    return RedirectToAction("LoginUser", "Login");
                }
                else
                {                    
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
