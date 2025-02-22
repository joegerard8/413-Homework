using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Models
{
    public class MovieContext : DbContext //inheriting from the DB context file, creating our own version of that class
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) //a constructor
        {
        }

        public DbSet<Movie> Movies { get; set; } //Movies table
        public DbSet<Category> Categories { get; set; } // cateogires table

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Movie>() //creaing the relationsihp between the categories and movies tables
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId);
        }

    }
}
