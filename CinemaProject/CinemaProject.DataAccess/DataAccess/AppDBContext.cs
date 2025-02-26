using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CinemaProject.DataAccess.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        // Parameterless constructor for design-time services (like migrations)
        public AppDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Provide a fallback connection string (for EF Core tools)
                optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=CinemaDB;Trusted_Connection=True;");
            }
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
