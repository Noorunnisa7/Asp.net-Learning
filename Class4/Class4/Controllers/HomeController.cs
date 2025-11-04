using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.data = "View Bag Method";
            ViewData["msg"] = "View data object";
            TempData["Message"] = "TEMp data object";
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            TempData.Keep("Message");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}