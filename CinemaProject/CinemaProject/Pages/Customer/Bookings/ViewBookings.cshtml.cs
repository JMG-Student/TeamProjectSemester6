using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Customer.Bookings
{
    public class ViewBookingsModel : PageModel
    {
        private readonly BookingService _bookingService;

        public ViewBookingsModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public List<Booking> Bookings { get; set; }

        public async Task OnGetAsync()
        {
            Bookings = await _bookingService.GetAllBookingsAsync();
        }
    }
}
