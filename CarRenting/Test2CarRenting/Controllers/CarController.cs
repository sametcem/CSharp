using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test2CarRenting.DAL;
using Test2CarRenting.Models;

namespace Test2CarRenting.Controllers
{
    public class CarController : Controller
    {
        public readonly IDbLayer _context;

        public CarController(IDbLayer context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Cars = _context.GetCars();
            ViewBag.Rents = _context.GetRents();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rent rentToAdd)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cars = _context.GetCars();
                ViewBag.Rents = _context.GetRents();


                return View("Index", rentToAdd);
            }

            _context.AddRent(rentToAdd);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.DeleteRent(id);
            return Redirect("/Car/Index");
        }

        public IActionResult UpdateRentingForm(int id)
        {
            var rent = _context.GetRent(id);
            ViewBag.Rent = rent;
            ViewBag.Cars = _context.GetCars();
            
            return View();
        }

        public IActionResult Update(int id, string description, string client, DateTime DateFrom, DateTime DateTo, int IdCar)
        {
            var rent = _context.GetRent(id);
            rent.Description = description;
            rent.Client = client;
            rent.DateFrom = DateFrom;
            rent.DateTo = DateTo;
            rent.IdCar = IdCar;
            _context.UpdateRent(rent);
            return Redirect("Index");

        }
    }
}