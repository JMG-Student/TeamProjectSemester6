using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Customer.Screenings
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Screening> Screenings;

        public IndexModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Screenings = _dbContext.Screenings
                .Include(s => s.Film)
                .ToList();
        }
    }
}
