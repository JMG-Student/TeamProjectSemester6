using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Screens
{
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public DeleteModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Screen Screen { get; set; }
        public void OnGet(int id)
        {
            Screen = _dbContext.Screens.Find(id);
        }

        public async Task<IActionResult> OnPost(Screen screen)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Screens.Remove(screen);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}