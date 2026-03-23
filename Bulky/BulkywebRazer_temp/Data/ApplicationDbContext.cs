using BulkywebRazer_temp.Model;
using Microsoft.EntityFrameworkCore;

namespace BulkywebRazer_temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // this is the class data connect the EntityFramwork to the database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //create tables from Model
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Docummentary", DisplayOrder = 4 }
               );
        }
    }
}
