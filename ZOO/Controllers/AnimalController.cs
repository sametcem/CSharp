using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test2Animal.DAL;
using Test2Animal.Models;

namespace Test2Animal.Controllers
{
    public class AnimalController : Controller
    {
        public readonly IDbLayer _context;

        public AnimalController(IDbLayer context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Animals = _context.GetAnimals();
            ViewBag.AnimalTypes = _context.GetAnimalTypes();
            ViewBag.Owners = _context.GetOwners();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animaltoAdd)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Animals = _context.GetAnimals();
                ViewBag.AnimalTypes = _context.GetAnimalTypes();
                ViewBag.Owners = _context.GetOwners();


                return View("Index", animaltoAdd);
            }

            _context.AddAnimal(animaltoAdd);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.DeleteAnimal(id);
            return Redirect("/Animal/Index");
        }

        public IActionResult UpdateAnimalForm(int id)
        {
            var animal = _context.GetAnimal(id);
            ViewBag.Animal = animal;
            ViewBag.Owners = _context.GetOwners();
            ViewBag.AnimalTypes = _context.GetAnimalTypes();
            return View();
        }


        public IActionResult Update(int id, string Name, int IdAnimalType, int IdOwner)
        {
            var animal = _context.GetAnimal(id);
            animal.Name = Name;
            animal.IdAnimalType = IdAnimalType;
            animal.IdOwner = IdOwner;
            _context.UpdateAnimal(animal);
            return Redirect("Index");
        }
    }
}