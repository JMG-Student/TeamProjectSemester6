using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Admin.Screens
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        [BindProperty]
        public Screen Screen { get; set; } = new Screen();

        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Screens.Add(Screen);
                await _dbContext.SaveChangesAsync();

                for (int row = 1; row <= Screen.Rows; row++)
                {
                    for (int col = 1; col <= Screen.Columns; col++)
                    {
                        var seat = new Seat
                        {
                            ScreenId = Screen.Id,
                            Row = row,
                            Column = col,
                            Type = "Standard",
                        };
                        _dbContext.Seats.Add(seat);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }

    }
}