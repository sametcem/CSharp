namespace RetakePrep3Animal.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnimDbCon : DbContext
    {
        public AnimDbCon()
            : base("name=AnimDbCon")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalType> AnimalTypes { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AnimalType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
