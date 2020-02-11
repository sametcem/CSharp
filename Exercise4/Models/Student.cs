using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

        public override string ToString()
        {
            // Lastname + " " + Firstname
            return $"{LastName}::{FirstName}";
        }
    }
}
