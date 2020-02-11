using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastApps.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string IndexNumber { get; set; }
        public Study Study { get; set; }
        public List<Subject> Subject { get; set; }

    }
}
