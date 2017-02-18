namespace HeroesApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HeroDbContext : DbContext
    {
        public HeroDbContext()
            : base("name=HeroDbContext")
        {
        }

        public virtual DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
