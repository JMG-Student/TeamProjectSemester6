using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Admin.Capacity
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Cap> cap { get; set; }  // ✅ Changed 'Screen' to 'screens' to match Razor Page

        public IndexModel(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void OnGet()
        {
            cap = _dbContext.Caps.ToList(); // ✅ Make sure to fetch data properly
        }
    }
}

