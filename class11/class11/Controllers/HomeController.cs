using System.Diagnostics;
using class11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace class11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //get 
        public IActionResult Index()
        {
            HttpContext.Session.SetString("username", "Noorunnisa");
            HttpContext.Session.SetInt32("UserId", 12);
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(IFormCollection frm)
        //{

        //}
        public IActionResult About()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();

            ViewBag.user =  HttpContext.Session.GetString("username");

            ViewBag.userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.email = HttpContext.Session.GetString("email");
            
            return View();
        }
        public IActionResult Privacy()
        {
            HttpContext.Session.SetString("email", "abc@gmail.com");
            //HttpContext.Session.Remove("key");
            //HttpContext.Session.Clear();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
