using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CinemaProject.DataAccess.DataAccess
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Cap> Caps { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
