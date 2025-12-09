using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Class14.Controllers
{
    public class EditorController : Controller
    {
        [Authorize(Roles = "Editor , Admin")]
        public IActionResult Index()
        {
            return Content("Only editor and Admin can access");
        }
    }
}
