using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2Animal.Models
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Animal> Animal_apbd { get; set; }
        public DbSet<AnimalType> AnimalType_apbd { get; set; }
        public DbSet<Owner> Owner_apbd { get; set; }



    }
}
