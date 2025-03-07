using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacity
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Cap> Caps { get; set; }  

        public IndexModel(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void OnGet()
        {
            Caps = _dbContext.Caps.ToList();
        }
    }
}
