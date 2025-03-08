using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Admin.Screens
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Screen> screens { get; set; } 

        public IndexModel(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void OnGet()
        {
            screens = _dbContext.Screens
                       .Include(s => s.Cap) 
                       .ToList();
        }
    }
}
