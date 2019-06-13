using api_sepomex.Models;
using Microsoft.EntityFrameworkCore;

namespace api_sepomex.Models {     
    public class IntranetContext : DbContext     
    {         
        public IntranetContext(DbContextOptions<IntranetContext> options): base(options)         
        {
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().Property(c => c.CountryID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(c => c.Id).ValueGeneratedOnAdd();
        }
        */
        public DbSet<Country> Country { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Employee> Employee { get; set; }
    } 
}