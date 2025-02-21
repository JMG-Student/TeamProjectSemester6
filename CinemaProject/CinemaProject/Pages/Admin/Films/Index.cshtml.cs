using CinemaProject.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models.Models;



namespace CinemaProject.Pages.Admin.Films
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;


        //public List<Models.Models.Film> Films { get; set; }
        public IEnumerable<Models.Models.Film> Films;


        public IndexModel(AppDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Films = _context.Films;
        }

    }
}
