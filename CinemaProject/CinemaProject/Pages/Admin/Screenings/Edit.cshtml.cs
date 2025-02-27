//using CinemaProject.DataAccess.DataAccess;
//using CinemaProject.Models.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace CinemaProject.Pages.Admin.Screenings
//{
//    public class EditModel : PageModel
//    {
//        private readonly AppDBContext _dbContext;

//        public EditModel(AppDBContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public Screening Screening { get; set; }
//        public IEnumerable<SelectListItem> ScreenList { get; set; }
//        public IEnumerable<SelectListItem> FilmList { get; set; }

//        public void OnGet(int id)
//        {

//            Screening = _dbContext.Screenings.Find(id);

//            // _dbContext.Screen shall be renamed as Screens
//            ScreenList = _dbContext.Screens.Select(i => new SelectListItem()
//            {
//                // Uncomment this line once all branches are merged 
//                Text = ("Screen " + (i.Id.ToString())),
//                Value = i.Id.ToString(),
//            });

//            FilmList = _dbContext.Films.Select(i => new SelectListItem()
//            {
//                // Uncomment this line once all branches are merged 
//                Text = i.Title,
//                Value = i.Id.ToString(),
//            });


//        }


//        public async Task<IActionResult> OnPost(Screening screening)
//        {
//            if (ModelState.IsValid)
//            {
//                _dbContext.Screenings.Update(screening);
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Screenings
{
    public class EditModel : PageModel
    {
        private readonly AppDBContext _dbContext;

        public EditModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Screening Screening { get; set; }

        public IEnumerable<SelectListItem> ScreenList { get; set; }
        public IEnumerable<SelectListItem> FilmList { get; set; }

        public void OnGet(int id)
        {
            Screening = _dbContext.Screenings.Find(id);

            ScreenList = _dbContext.Screens.Select(i => new SelectListItem()
            {
                Text = "Screen " + i.Id.ToString(),
                Value = i.Id.ToString(),
            });

            FilmList = _dbContext.Films.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate dropdowns if validation fails
                ScreenList = _dbContext.Screens.Select(i => new SelectListItem()
                {
                    Text = "Screen " + i.Id.ToString(),
                    Value = i.Id.ToString(),
                });

                FilmList = _dbContext.Films.Select(i => new SelectListItem()
                {
                    Text = i.Title,
                    Value = i.Id.ToString(),
                });

                return Page();
            }

            // Retrieve the existing screening from the database
            var existingScreening = await _dbContext.Screenings.FindAsync(Screening.Id);
            if (existingScreening == null)
            {
                return NotFound();
            }

            // Update the properties of the existing entity
            existingScreening.Time = Screening.Time;
            existingScreening.ScreenID = Screening.ScreenID;
            existingScreening.FilmID = Screening.FilmID;

            _dbContext.Screenings.Update(existingScreening);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}