using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Screenings
{
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public DeleteModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Screening Screening { get; set; }
        public IEnumerable<SelectListItem> ScreenList { get; set; }
        public IEnumerable<SelectListItem> FilmList { get; set; }

        public void OnGet(int id)
        {
            Screening = _dbContext.Screenings.Find(id);

            // _dbContext.Screen shall be renamed as Screens
            ScreenList = _dbContext.Screens.Select(i => new SelectListItem()
            {
                // Uncomment this line once all branches are merged 
                Text = ("Screen " + (i.Id.ToString())),
                Value = i.Id.ToString(),
            });

            FilmList = _dbContext.Films.Select(i => new SelectListItem()
            {
                // Uncomment this line once all branches are merged 
                Text = i.Title,
                Value = i.Id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost(Screening screening)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Screenings.Remove(screening);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}