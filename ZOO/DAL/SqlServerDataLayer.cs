using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2Animal.Models;

namespace Test2Animal.DAL
{
    public class SqlServerDataLayer : IDbLayer
    {
        private readonly AnimalDbContext _context;

        public SqlServerDataLayer(AnimalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animal_apbd.Include(a => a.AnimalType).Include(a => a.Owner).OrderBy(a => a.Name).ToList();
        }

        public void AddAnimal(Animal newAnimal)
        {
            _context.Animal_apbd.Add(newAnimal);
            _context.SaveChanges();
        }

        public void DeleteAnimal(int deletedAnimalid)
        {
            var animal = _context.Animal_apbd.FirstOrDefault(a => a.IdAnimal == deletedAnimalid);

            if(animal != null)
            {
                _context.Animal_apbd.Remove(animal);
                _context.SaveChanges();
            }
        }

        public Animal GetAnimal(int id)
        {
            return _context.Animal_apbd.FirstOrDefault(a => a.IdAnimal == id);
        }

         public Owner GetOwner(int id)
        {
            return _context.Owner_apbd.FirstOrDefault(o => o.IdOwner == id);
        }

        public AnimalType GetAnimalType(int id)
        {
            return _context.AnimalType_apbd.FirstOrDefault(t => t.IdAnimalType == id);
        }

       
        public IEnumerable<AnimalType> GetAnimalTypes()
        {
            return _context.AnimalType_apbd.OrderBy(a => a.Name).ToList();
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owner_apbd.OrderBy(o => o.FirstName).ThenBy(o => o.LastName).ToList();
        }

       
        public void UpdateAnimal(Animal updatedAnimal)
        {
            if(updatedAnimal != null)
            {
                _context.Animal_apbd.Update(updatedAnimal);
                _context.SaveChanges();
            }
        }
    }
}
