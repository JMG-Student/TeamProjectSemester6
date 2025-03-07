using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class BookingService
    {
        private readonly AppDBContext _context;

        public BookingService(AppDBContext context)
        {
            _context = context;
        }

        // ✅ Get All Bookings
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Screening)
                .Include(b => b.User)
               .Include(b => b.Seat)
                .ToListAsync();
        }

        // ✅ Get Booking by ID
        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Screening)
                .Include(b => b.User)
                //.Include(b => b.Seat)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // ✅ Add Booking
        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            var screening = await _context.Screenings.FindAsync(booking.ScreeningId);
            if (screening == null) return false; // Screening does not exist

            // Check if seat is already booked
            var seatTaken = await _context.Bookings.AnyAsync(b =>
                b.ScreeningId == booking.ScreeningId && b.SeatId == booking.SeatId);

            if (seatTaken) return false; // Seat already booked

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Update Booking
        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.FindAsync(booking.Id);
            if (existingBooking == null)
                return false;

            existingBooking.ScreeningId = booking.ScreeningId;
            existingBooking.SeatId = booking.SeatId;
            existingBooking.Price = booking.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Delete Booking
        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
