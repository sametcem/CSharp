using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2PrepTekrar.Models
{
    public class PlayerDbCon : DbContext
    {
        public PlayerDbCon(DbContextOptions opt) : base(opt)
        {

        }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17181;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Player>().HasKey(p =>  new
                                                {  p.IdPlayer, p.IdTeam
                                                  }); // [Key] - if many to many table it is */
            
            /*
            modelBuilder.Entity<Player>().Property(p => p.LastName).IsRequired().HasMaxLength(150); 
            */

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Player> Player_apbd { get; set; }
        public DbSet<Team> Team_apbd { get; set; }

    }
}
