using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task10Tekrar.Models
{
    public class Student
    {
        public int IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public Study Study { get; set; }

    }
    public class Study
    {
        public int IdStudies { get; set; }
        public string Name { get; set; }
    }
}
