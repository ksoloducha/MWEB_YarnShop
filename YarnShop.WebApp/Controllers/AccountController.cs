using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using YarnShop.WebApp.Models;

namespace YarnShop.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = await _userManager.FindByNameAsync(login.UserName);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in succesfully");
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Wrong username or password");
            _logger.LogError("User not logged in, wrong username or password");
            return View(login);
        }

        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = login.UserName };
                var result = await _userManager.CreateAsync(user, login.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created");
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid data. Password must contain uppercase letter, digit and special character.");
            _logger.LogError("User not created, invalid password");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out");
            return RedirectToAction("Index", "Home");
        }
    }
}
