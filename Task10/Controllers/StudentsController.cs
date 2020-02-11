using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task10.Models;

namespace Task10.Controllers
{
    public class StudentsController : Controller
    {
        List<Student> lst;

        public StudentsController()
        {
            lst = new List<Student>()
            {   new Student {IdStudent = 1,FirstName = "Louis",LastName = "Tyson",Address = "Ankara",IndexNumber = "s17181",StudyName = "Computer Science"},
                new Student { IdStudent = 2, FirstName = "Jack", LastName = "Jones", Address = "Istanbul", IndexNumber = "s17182", StudyName = "Media Art" },
                new Student { IdStudent = 3, FirstName = "Frey", LastName = "Mark", Address = "Izmir", IndexNumber = "s17183", StudyName = "Database" }
            };
            
        }
        public IActionResult Index()
        {

            //ViewBag.Message = "Dude,its simple.";
            return View(lst);
        }

        public ActionResult Delete(int? i)
        {
            var st = lst.Find(c => c.IdStudent == i);
            lst.Remove(st);
            return View("Index", lst);
        }

        public ActionResult Add()
        {
            var std = new Student() {
                IdStudent = 4,
                FirstName = "Smith",
                LastName = "Jordan",
                Address = "Karaman",
                IndexNumber = "s17184",
                StudyName = "Computer Science"
            
        };
            lst.Add(std);
            return View("Index", lst);
        }


    }
}