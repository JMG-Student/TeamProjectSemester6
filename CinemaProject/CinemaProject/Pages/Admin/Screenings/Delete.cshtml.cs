using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet(int id)
        {
            Screening = _dbContext.Screenings.Find(id);
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
