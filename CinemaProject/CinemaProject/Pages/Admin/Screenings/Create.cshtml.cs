using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Admin.Screenings
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Screening Screening{ get; set; }

        public IEnumerable<SelectListItem> ScreenList { get; set; }
        public void OnGet()
        {
            ScreenList = _dbContext.Screen.Select(i => new SelectListItem()
            {
                //Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost(Screening screening)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Screenings.AddAsync(screening);
                _dbContext.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}
