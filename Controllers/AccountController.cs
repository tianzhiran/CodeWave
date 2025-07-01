using Microsoft.AspNetCore.Mvc;
using FlixNow.Models;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace FlixNow.Controllers
{
    // Controller for handling user account actions (registration and login)
    public class AccountController : Controller
    {
        // Database context for accessing Users table
        private readonly AppDbContext _context;

        // Constructor: DI will automatically inject AppDbContext
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Show the registration page   
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Handle registration form submission
        [HttpPost]
        public IActionResult Register(User user)
        {
            // 验证 Role 必须为 Admin 或 Customer
            if (user.Role != "Admin" && user.Role != "Customer")
            {
                ModelState.AddModelError("Role", "Invalid role selected.");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // Show the login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Handle login form submission
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string role, string returnUrl)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role == role);
            if (user != null)
            {
                // 创建 Claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // 跳转
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.Error = "Invalid email, password, or role";
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear(); // 可选：清空 Session
            return RedirectToAction("Login", "Account"); // 或跳回首页 Index, "Home"
        }
        [Authorize]
        public IActionResult Profile()
        {
            // 当前登录邮箱
            string email = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return NotFound();

            return View(user);
        }

        
    }
}
