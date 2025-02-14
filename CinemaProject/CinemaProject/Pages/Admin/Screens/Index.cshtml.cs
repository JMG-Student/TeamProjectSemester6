using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.DataAccess.DataAccess;

namespace CinemaProject.Pages.Admin.Screens
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Models.Models.Screen> Screens;
        public IndexModel(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public void OnGet()
        {
            Screens = _dbContext.Screen;
        }
    }
}
