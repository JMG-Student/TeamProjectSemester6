using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;


namespace CinemaProject.Pages.Admin.Film
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _context;
        public CinemaProject.Models.Models.Film? Film { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _context.Films.Add(Film);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
