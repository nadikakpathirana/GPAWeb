using GPAWeb.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GPAWeb.DAL.DataContext
{
    public class GPADbContext : DbContext
    {
        public GPADbContext(DbContextOptions<GPADbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = new Guid(),
                     Username = "nadikakpathirana",
                     Password = "12345",
                     FirstName = "Nadika",
                     LastName = "Pathirana",
                 }
             );
        }
    }
}
