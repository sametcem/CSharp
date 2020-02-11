using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }


        // Every public method in a controller is callable as an HTTP endpoint.
        // GET: /HelloWorld/     Http Get

        //        public string Index()
        //        {
        //            return "This is my default action...";
        //        }

        // 
        // GET: /HelloWorld/Welcome/    Http Get
        ///HelloWorld/Welcome?name=Rick&numtimes=4
        //        public string Welcome(string name, int numTimes = 1)
        //        {
        //            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //        }
        // /HelloWorld/Welcome/3?name=Rick
        public string Welcome2(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}