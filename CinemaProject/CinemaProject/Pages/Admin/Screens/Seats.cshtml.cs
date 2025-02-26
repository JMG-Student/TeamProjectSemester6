using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CinemaProject.Pages.Admin.Screens
{
    public class SeatsModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public void OnGet()
        {
        }

        public Screen Screen { get; set; }
        public List<Seat> Seats { get; set; }
        public async Task<IActionResult> OnPostAsync(int[] selectedSeats)
        {
            var seats = await _dbContext.Seats
                .Where(s => selectedSeats.Contains(s.Id))
                .ToListAsync();

            foreach (var seat in seats)
            {
                seat.IsReserved = true;
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
