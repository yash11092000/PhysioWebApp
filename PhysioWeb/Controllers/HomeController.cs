using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhysioWeb.Models;
using BCrypt.Net;
using PhysioWeb.Repository;

namespace PhysioWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
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
        [HttpGet]
        public async Task<ActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(Users users) {
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
            var res = await _homeRepository.RegisterUser(users);
            return Json(res);
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
