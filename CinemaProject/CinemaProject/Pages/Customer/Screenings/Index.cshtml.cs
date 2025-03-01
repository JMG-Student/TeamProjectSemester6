using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Pages.Customer
{
    public class ScreeningsModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public ScreeningsModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty(SupportsGet = true)]
        public int? FilmId { get; set; }

        public List<Screening> Screenings { get; set; }

        public void OnGet()
        {
            var query = _dbContext.Screenings
                .Include(s => s.Film)
                .Include(s => s.Screen)
                .AsQueryable();

            if (FilmId.HasValue)
            {
                query = query.Where(s => s.Film.Id == FilmId.Value);
            }

            Screenings = query.ToList();
        }
    }
}