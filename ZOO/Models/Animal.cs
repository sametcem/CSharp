using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2Animal.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }

        [Required, MaxLength(255)]
        [Display(Name="Animal Name")]
        public string Name { get; set; }

        
        [Display(Name="Animal Type")]
        public int IdAnimalType { get; set; }

        
        [Display(Name = "Owner Name")]
        public int IdOwner { get; set; }

        [ForeignKey("IdAnimalType")]
        public AnimalType AnimalType { get; set; }

        [ForeignKey("IdOwner")]
        public Owner Owner { get; set; }
    }
}
