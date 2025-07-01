
using System.Diagnostics;
using FlixNow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // for session

namespace FlixNow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ??
        public IActionResult Index()
        {
            return View();
        }

        // Explore logic to jump to next page
        [HttpPost]
        public IActionResult Explore()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}