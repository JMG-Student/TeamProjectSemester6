using CinemaProject.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models.Models;



namespace CinemaProject.Pages.Admin.Films
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public IEnumerable<Film> Films;

        public IndexModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Films = _dbContext.Films
                .Include(a => a.Genre)
                .ToList();
        }
    }
}
