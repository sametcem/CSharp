using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2Animal.Models
{
    public class AnimalType
    {
        [Key]
        public int IdAnimalType { get; set; }
        public string Name { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}
