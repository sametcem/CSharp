using System.Windows.Controls;

namespace RetakePrep3Animal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Animal")]
    public partial class Animal
    {
        [Key]
        public int IdAnimal { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? IdAnimalType { get; set; }

        public int? IdOwner { get; set; }

        [ForeignKey("IdAnimalType")]
        public virtual AnimalType AnimalType { get; set; }

        [ForeignKey("IdOwner")]
        public virtual Owner Owner { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
