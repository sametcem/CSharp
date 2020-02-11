using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2Animal.Models
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }

        public ICollection<Animal> HisAnimals { get; set; }

    }
}
