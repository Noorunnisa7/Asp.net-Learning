using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Class6.Models;

namespace Class6.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            //var student = new Student {Id = 1 , Name = "Ali" , age = 24};
            var students = new List<Student>{
                new Student { Id = 1, Name = "Ali", age = 24 },
                 new Student { Id = 2, Name = "Raza", age = 25 },
                  new Student { Id = 3, Name = "Hassan", age = 26 },
                   new Student { Id = 4, Name = "Haider", age = 23 }
            };
            return View(students);
        }
    }
}