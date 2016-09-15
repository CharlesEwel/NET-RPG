using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using epicodus_dotnet_rpg.ViewModels;
using epicodus_dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace epicodus_dotnet_rpg.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            await this._userManager.AddToRoleAsync(user, "BasicUser");
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            return View(_db.Users.ToList());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Detail(string id)
        {
            ViewBag.Roles = _db.Roles.ToList();
            var currentUser = await _userManager.FindByIdAsync(id);
            ViewBag.UserId = id;
            ViewBag.UserName = currentUser.UserName;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Detail(ManageUserRolesViewModel model)
        {
            var currentUser = await _userManager.FindByIdAsync(model.UserId);
            await this._userManager.AddToRoleAsync(currentUser, model.RoleName);
            return RedirectToAction("UserList");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}