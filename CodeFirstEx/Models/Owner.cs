using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEx.Models
{
    //Fluent API     -- Often called POCO - Plain Old CLR Class
    public class Owner
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
