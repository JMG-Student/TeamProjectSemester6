using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Services;


namespace CinemaProject.Pages.Customer.Bookings
{

    public class TicketSelectionModel : PageModel
    {
        private readonly ScreeningService _screeningService;
        private readonly FilmService _filmService;

        public TicketSelectionModel(ScreeningService screeningService, FilmService filmService)
        {
            _screeningService = screeningService;
            _filmService = filmService;
        }

        [BindProperty(SupportsGet = true)]
        public int FilmId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScreeningId { get; set; }

        public Film Film { get; set; } = new Film(); // ? Fix: Initialize Film
        public List<Screening> Screenings { get; set; } = new List<Screening>(); // ? Fix: Initialize List

        public async Task<IActionResult> OnGetAsync()
        {
            Film = await _filmService.GetFilmByIdAsync(FilmId);
            Screenings = await _screeningService.GetScreeningsByFilmIdAsync(FilmId);

            if (Film == null || !Screenings.Any())
            {
                return RedirectToPage("/Customer/Home/Index"); // Redirect if no screenings found
            }

            return Page();
        }
    }
}

