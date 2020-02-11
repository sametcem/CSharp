using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2Animal.Models;

namespace Test2Animal.DAL
{
    public interface IDbLayer
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<AnimalType> GetAnimalTypes();
        IEnumerable<Owner> GetOwners();

        Animal GetAnimal(int id);
        AnimalType GetAnimalType(int id);
        Owner GetOwner(int id);

        void AddAnimal(Animal newAnimal);
        void DeleteAnimal(int deletedAnimalid);
        void UpdateAnimal(Animal updatedAnimal);

    }
}
