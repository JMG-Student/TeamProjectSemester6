using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;

namespace CinemaProject.Pages.Admin.Screens
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        [BindProperty]
        public Screen Screen { get; set; } = new Screen(); // Ensure it's initialized

        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Screen screen)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Screen.AddAsync(screen);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }

    }
}
