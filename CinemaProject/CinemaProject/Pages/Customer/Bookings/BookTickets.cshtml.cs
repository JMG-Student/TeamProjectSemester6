using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Pages.Customer.Bookings
{
    public class BookTicketsModel : PageModel
    {
        private readonly ScreeningService _screeningService;
        private readonly BookingService _bookingService;

        public BookTicketsModel(ScreeningService screeningService, BookingService bookingService)
        {
            _screeningService = screeningService;
            _bookingService = bookingService;
        }

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        [BindProperty]
        public string TicketType { get; set; } = "Adult";

        [BindProperty]
        public int NumberOfTickets { get; set; } = 1;

        public List<Screening> Screenings { get; set; } = new List<Screening>();

        public async Task<IActionResult> OnGetAsync(int filmId)
        {
            Screenings = await _screeningService.GetScreeningsByFilmIdAsync(filmId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Calculate ticket price
            decimal ticketPrice = TicketType switch
            {
                "Adult" => 10m,
                "Child" => 7m,
                "Senior" => 8m,
                _ => 10m
            };

            Booking.Price = ticketPrice * NumberOfTickets;
            Booking.BookingDate = DateTime.Now;

            await _bookingService.CreateBookingAsync(Booking);

            return RedirectToPage("/Customer/Home/Index");
        }
    }
}
