//using CinemaProject.DataAccess.DataAccess;
//using CinemaProject.Models.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace CinemaProject.Pages.Admin.Films
//{
//    public class DeleteModel : PageModel
//    {
//        private readonly AppDBContext _dbContext;
//        public DeleteModel(AppDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        [BindProperty]
//        public Film Film { get; set; }

//        public void OnGet(int id)
//        {
//            Film = _dbContext.Films.Find(id);
//        }

//        public async Task<IActionResult> OnPost()
//        {
//            var film = _dbContext.Films.Find(Film.Id);

//            if (ModelState.IsValid)
//            {
//                _dbContext.Films.Remove(film);
//                await _dbContext.SaveChangesAsync();
//            }
//            return RedirectToPage("Index");
//        }
//    }
//}



using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

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
            // Fetch the film from the database
            Film = _dbContext.Films.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            // Fetch the film from the database again to ensure it is tracked
            var filmToDelete = _dbContext.Films.Find(Film.Id);

            if (filmToDelete == null)
            {
                // If the film is not found, return a not found error
                return NotFound();
            }

            // Remove the film from the database
            _dbContext.Films.Remove(filmToDelete);
            await _dbContext.SaveChangesAsync();

            // Redirect to the Index page
            return RedirectToPage("Index");
        }
    }
}
