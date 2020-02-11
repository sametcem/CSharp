using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEx.Models
{
    public class AnimalType
    {
        [Key]
        public int IdAnimalType { get; set; } // If Icannot call ID, Ef doesnt know its primary key  call [Key]

        [Required,MaxLength(150)]
        public string Name { get; set; } // Dog

        //If we added new class we have to add DbSet to DbContext
        // IEnumarable <- ICollection<T>   -> to add data we will use ICollection

        public ICollection<Animal> Animals { get; set; }   // Foreign Key

    }
}
