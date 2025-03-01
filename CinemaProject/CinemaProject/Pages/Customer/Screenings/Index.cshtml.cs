//using CinemaProject.DataAccess.DataAccess;
//using CinemaProject.Models.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;

//namespace CinemaProject.Pages.Customer.Screenings
//{
//    public class IndexModel : PageModel
//    {
//        private readonly AppDBContext _dbContext;
//        public IEnumerable<Screening> Screenings;

//        public IndexModel(AppDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public void OnGet()
//        {
//            Screenings = _dbContext.Screenings
//                .Include(s => s.Film)
//                .ToList();
//        }
//    }
//}

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
        public int? FilmId { get; set; } // Query parameter for filtering by film ID

        public List<Screening> Screenings { get; set; }

        public void OnGet()
        {
            // Fetch all screenings
            var query = _dbContext.Screenings
                .Include(s => s.Film)
                .Include(s => s.Screen)
                .AsQueryable();

            // Filter screenings by FilmId if provided
            if (FilmId.HasValue)
            {
                query = query.Where(s => s.Film.Id == FilmId.Value);
            }

            Screenings = query.ToList();
        }
    }
}