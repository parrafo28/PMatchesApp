using Microsoft.AspNetCore.Mvc;
using PMatches.Frontend.Models;
using System.Diagnostics;

namespace PMatches.Frontend.Controllers
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
        public IActionResult Index2()
        {
            return View("Index");
        }
        public IActionResult Privacy()
        {
            ViewBag.TextFromTest = "Esto es un texto de prueba";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
