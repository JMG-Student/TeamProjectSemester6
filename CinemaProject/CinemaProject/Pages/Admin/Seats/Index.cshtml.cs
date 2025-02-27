using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Pages.Admin.Seats
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public IndexModel(AppDBContext context)
        {
            _dbContext = context;
        }

        public List<Screen> Screens { get; set; } // List of all screens
        public List<Seat> Seats { get; set; } // Seats for the selected screen
        public int? SelectedScreenId { get; set; } // ID of the selected screen
        public Screen SelectedScreen { get; set; } // Details of the selected screen

        public async Task OnGetAsync(int? screenId)
        {
            // Fetch all screens
            Screens = await _dbContext.Screens.ToListAsync();

            // If a screen is selected, fetch its seats
            if (screenId.HasValue)
            {
                SelectedScreenId = screenId.Value;
                SelectedScreen = await _dbContext.Screens.FindAsync(screenId.Value);
                Seats = await _dbContext.Seats
                    .Where(s => s.ScreenId == screenId.Value)
                    .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(int screenId, List<int> selectedSeats)
        {
            if (selectedSeats == null || !selectedSeats.Any())
            {
                return RedirectToPage(new { screenId });
            }

            // Find and update selected seats
            var seatsToUpdate = await _dbContext.Seats
                .Where(s => selectedSeats.Contains(s.Id))
                .ToListAsync();

            foreach (var seat in seatsToUpdate)
            {
                seat.IsReserved = true;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToPage(new { screenId });
        }
    }
}
