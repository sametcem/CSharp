using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEx.Models
{
    public class Animal
    {
        public int Id{ get; set; }  // One way just call it Id 

        [Required,MaxLength(150)]
        public string Name { get; set; } // Ncarchar(150 ) Not Nullable -> Required
        [Required, MaxLength(150)]
        public string Description { get; set; }
        public int Age { get; set; } // INT Non-Nullable  ? makes it nullable

        [MaxLength(150)]
        public string Owner { get; set; }

        // Shadow property yazmazsak ya da şöyle
        // db.Animals.Where(d=> d.IdAnimalType ==1) without joining -> direct solution
        //vs
        //db.Animal.Where(d => d.AnimalType.IdAnimalType==1)

        [ForeignKey("AnimalType")]
        public int IdAnimalType { get; set; } // Name of the fk column
        public AnimalType AnimalType { get; set; }
    }
}
