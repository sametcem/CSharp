using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2PrepTekrar.Models
{
    public class Team
    {
        [Key]
        public int IdTeam { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
