using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Class14.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles ="User , Admin")]
        public IActionResult Index()
        {
            return Content("Only User and admin can access this page");
        }
    }
}
