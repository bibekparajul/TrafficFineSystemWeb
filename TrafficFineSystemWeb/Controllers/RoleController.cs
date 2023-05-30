using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TrafficFineSystemWeb.Controllers
{
    public class RoleController : Controller
    {


        private RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
