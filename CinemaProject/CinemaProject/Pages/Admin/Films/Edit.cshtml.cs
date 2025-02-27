using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Films
{
    public class EditModel : PageModel
    {
        private readonly AppDBContext _dbContext;

       
        public EditModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public Film Film { get; set; }

        public List<SelectListItem> GenreList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Children", Text = "Children" },
            new SelectListItem { Value = "Action", Text = "Action" },
            new SelectListItem { Value = "Comedy", Text = "Comedy" },
            new SelectListItem { Value = "Drama", Text = "Drama" },
            new SelectListItem { Value = "Horror", Text = "Horror" },
            new SelectListItem { Value = "Sci-Fi", Text = "Sci-Fi" },
            new SelectListItem { Value = "Romance", Text = "Romance" },
            new SelectListItem { Value = "Thriller", Text = "Thriller" },
            new SelectListItem { Value = "Fantasy", Text = "Fantasy" },
            new SelectListItem { Value = "Documentary", Text = "Documentary" }
        };


        public IActionResult OnGet(int id)
        {
            Film = _dbContext.Films.Find(id);
            if (Film == null)
            {
                return RedirectToPage("Index"); 
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Films.Update(Film);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }

       
    }
}

       