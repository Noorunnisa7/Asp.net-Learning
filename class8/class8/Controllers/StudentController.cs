using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using class8.Models;

namespace class8.Controllers
{
    public class StudentController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            SqlConnection con = new SqlConnection(cs);
            string query = "Select * from student";
            SqlCommand queryRun = new SqlCommand(query, con);
            con.Open();
            var fetch = queryRun.ExecuteReader();

            while (fetch.Read())
            {
                //students.Add(new Student{  });

                students.Add(new Student
                {
                    Id = Convert.ToInt32(fetch["id"]),
                    Name = fetch["name"].ToString(),
                    Age = Convert.ToInt32(fetch["age"]),
                    Address = fetch["stdaddress"].ToString()
                });
            }


            return View(students);
        }

        
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into student (name , age , stdaddress) values ( @name , @age , @address )";

                SqlCommand queryRun = new SqlCommand(query, con);
                con.Open();
                queryRun.Parameters.AddWithValue("@name", std.Name);
                queryRun.Parameters.AddWithValue("@age", std.Age);
                queryRun.Parameters.AddWithValue("@address", std.Address);

                queryRun.ExecuteNonQuery();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
