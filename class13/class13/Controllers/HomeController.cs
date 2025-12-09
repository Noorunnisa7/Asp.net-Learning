using System.Diagnostics;
using class13.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
namespace class13.Controllers
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
            string password = "abc@#321654"; // db
            string hashed = BCrypt.Net.BCrypt.HashPassword(password);

            bool verifyPass = BCrypt.Net.BCrypt.Verify("abc@#321654", hashed);

            if (verifyPass)
            {
                ViewBag.result = "Password is correct";
            }
            else
            {
                ViewBag.result = "Incorrect Password";
            }

                ViewBag.hashed = hashed;
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
    }
}
