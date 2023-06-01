using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

  

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            IdentityUser iUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.Phone
            };
            IdentityResult result = await _userManager.CreateAsync(iUser, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(iUser, user.Role);
                return Redirect("/");
            }
            var roles = _roleManager.Roles.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            }).ToList();

            ViewBag.Roles = roles;
            return View(user);
        }
        [HttpGet]

        public IActionResult Login()
        {
      
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            IdentityUser u = await _userManager.FindByEmailAsync(model.Email);
            if (u != null)
            {
                bool res = await _userManager.CheckPasswordAsync(u, model.Password);

                if (res)
                {
                    await _signInManager.SignInAsync(u, true);

                    return RedirectToAction("Index", "Home");
                }



            }
            TempData["error"] = "Please enter the valid Email and Password";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["success"] = "User Logged Successfully";

            return RedirectToAction("Login", "Account");

        }

   


    }
}
