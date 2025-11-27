using System.Diagnostics;
using class10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace class10.Controllers
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
            try
            {
                MailMessage mail = new MailMessage();
                // add , from , body , subject , body html
                mail.To.Add("noorunnisa560@gmail.com");
                mail.To.Add("noorunnisa5000@gmail.com");

                mail.From = new MailAddress("noorunnisa560@gmail.com");
                mail.Subject = "Asp.net MVC Core Mail";
                mail.Body = "<h1>Hello Asp mailer</h1>";
                mail.IsBodyHtml = true;
                mail.ReplyTo = new MailAddress("abc@gmail.com");

                SmtpClient smtp = new SmtpClient();
                smtp.Host= "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("noorunnisa560@gmail.com", "");

                smtp.Send(mail);


            }
            catch (Exception ex) {
                ViewBag.error = ex.Message;
            }
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
