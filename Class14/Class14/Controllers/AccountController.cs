using Microsoft.AspNetCore.Mvc;
using Class14.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
namespace Class14.Controllers
{
    public class AccountController : Controller
    {
        public string cs = "Data Source=TEACHER;Initial Catalog=login_system;Integrated Security=True;Encrypt=False";


        public IActionResult Register()
        {
            //email 
            // name email pass compass  role
            return View();
        }
        //Get
        public IActionResult Login()
        {
            return View();

        }
        //Post
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "SELECT Username,Role from Users where Username = @u  AND Password = @p";
            SqlCommand queryRun = new SqlCommand(query, con);
            queryRun.Parameters.AddWithValue("@u", model.Username);
            queryRun.Parameters.AddWithValue("@p", model.Password);

            SqlDataReader row = queryRun.ExecuteReader();
            if (row.Read())
            {
                string role = row["Role"].ToString();


                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name ,model.Username),
                    new Claim(ClaimTypes.Role, role)
                };

                var identity = new ClaimsIdentity(claim ,"CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                //User.Identity.Name()

                HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "Home");

            }

            ViewBag.Error = "Invalid credentials!";

            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}
