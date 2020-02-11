using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEx.Models
{
    public class AnimalDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Animal> Animals { get; set; } //then go Package Manager Console and write add-migration
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<AnimalClinic> AnimalClinics { get; set; }
        public DbSet<BirdClinic> BirdClinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Owner>().Property(s => s.FirstName)
                                                    .IsRequired()
                                                    .HasMaxLength(150);
            base.OnModelCreating(modelBuilder);
        }

    }
}
