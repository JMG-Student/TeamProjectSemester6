using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Pages.Admin.Screens
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Screen> screens { get; set; }  // ✅ Changed 'Screen' to 'screens' to match Razor Page

        public IndexModel(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void OnGet()
        {
            screens = _dbContext.Screens.ToList(); // ✅ Make sure to fetch data properly
        }
    }
}
