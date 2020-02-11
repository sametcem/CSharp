using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2CarRenting.Models;

namespace Test2CarRenting.DAL
{
    public class SqlServerDataLayer : IDbLayer
    {
        private readonly CarDbCon _context;

        public SqlServerDataLayer(CarDbCon context)
        {
            _context = context;
        }

        public void AddRent(Rent newRent)
        {
            if(newRent.DateTo>= newRent.DateFrom)
            {
                _context.Rents.Add(newRent);
                _context.SaveChanges();
            }
            
        }

        public void DeleteRent(int deletedRentId)
        {
            var rent = _context.Rents.FirstOrDefault(c => c.IdRent == deletedRentId);

            if(rent != null)
            {
                _context.Rents.Remove(rent);
                _context.SaveChanges();
            }
        }

        public Car GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.IdCar == id);
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars
                                .Include(c => c.Rents)
                                .OrderBy(c => c.RegisterNumber)
                                .ThenBy(c => c.Model)
                                .ToList();
        }

        public Rent GetRent(int id)
        {
            return _context.Rents.FirstOrDefault(r => r.IdRent == id);
        }

        public IEnumerable<Rent> GetRents()
        {
            return _context.Rents.OrderBy(r => r.DateFrom).ToList();
        }

        public void UpdateRent(Rent updatedRent)
        {
            if(updatedRent != null)
            {
                if(updatedRent.DateTo >= updatedRent.DateFrom)
                {
                    _context.Rents.Update(updatedRent);
                    _context.SaveChanges();
                }
               
            }
        }
    }
}
