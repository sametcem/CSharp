using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2PrepTekrar.Models
{
    public class Player
    {
        [Key]
        public int IdPlayer { get; set; }

        public string BirthDate { get; set; }

        [Required(ErrorMessage ="Imie jest wymagane"), MaxLength(150)]
        [Display(Name ="Imie")]
        public string FirstName { get; set; }

        [Required, MaxLength(150)]
        [Display(Name="Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Team Name")]
        public int IdTeam { get; set; }

        [ForeignKey("IdTeam")]
        public Team Team { get; set; }
    }
}
