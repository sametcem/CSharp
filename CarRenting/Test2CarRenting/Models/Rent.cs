using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2CarRenting.Models
{
    public class Rent
    {
        [Key]
        public int IdRent { get; set; }

        [Required(ErrorMessage = "Decription is needed!"), MaxLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Client Name is needed!"), MaxLength(255)]
        [Display(Name ="Client Name")]
        public string Client { get; set; }

        [Display(Name ="Renting Start Time")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Renting Finish Time")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Model")]
        public int IdCar { get; set; }

        [ForeignKey("IdCar")]
        public Car Car { get; set; }


    }
}
