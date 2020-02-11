using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2CarRenting.Models;

namespace Test2CarRenting.DAL
{
    public interface IDbLayer
    {
        IEnumerable<Car> GetCars();
        IEnumerable<Rent> GetRents();
        Car GetCar(int id);
        Rent GetRent(int id);

        void AddRent(Rent newRent);
        void DeleteRent(int deletedRentId);
        void UpdateRent(Rent updatedRent);

    }
}
