using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhysioWeb.Models;

namespace PhysioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<ActionResult> Login()
        {
            return View();
        }

        public async Task<ActionResult> Register()
        {
            return View();
        }

        public async Task<ActionResult> AboutUs()
        {
            return View();
        }

        public async Task<ActionResult> ContactUs()
        {
            return View();
        }
    }
}
