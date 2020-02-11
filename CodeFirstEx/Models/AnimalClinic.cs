using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEx.Models
{
    [Table("KlinikaZwierzat", Schema="apbd")]
    public class AnimalClinic
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class BirdClinic : AnimalClinic
    {
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
