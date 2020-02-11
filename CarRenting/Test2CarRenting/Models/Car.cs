using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2CarRenting.Models
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }

        public string RegisterNumber { get; set; }
        public string Model { get; set; }

        public ICollection<Rent> Rents { get; set; }

    }
}
