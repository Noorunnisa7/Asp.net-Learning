using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using class12.Models;
using Microsoft.AspNetCore.Identity;

namespace class12.Controllers
{
    public class AccountController : Controller
    {
        public List<LoginViewModel> users = new List<LoginViewModel> { 
          new LoginViewModel{username = "admin" , password = "12345" }
        };



        //get
        public IActionResult Index()
        {
            return View();
        }
        //post
        [HttpPost]
        public IActionResult Index(string username , string password)
        {

            var user = users.FirstOrDefault(x => x.username == username && x.password == password);

            if (user == null)
            {
                return View("Index");
            }
            HttpContext.Session.SetString("username", username);

            return RedirectToAction("Dashboard" , "Home");

            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
