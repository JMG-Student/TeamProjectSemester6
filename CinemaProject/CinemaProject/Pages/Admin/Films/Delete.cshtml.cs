using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Films
{
    public class DeleteModel : PageModel
    {
       
        private readonly AppDBContext _dbContext;


        public DeleteModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public Film Film { get; set; }



        public void OnGet(int id)
        {
            Film = _dbContext.Films.Find(id);
        }

        public async Task<IActionResult> OnPost(Film film)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Films.Remove(film);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
