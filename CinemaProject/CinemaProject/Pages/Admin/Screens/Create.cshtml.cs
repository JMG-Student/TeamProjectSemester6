using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Screens
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDBContext _dbContext;

        public CreateModel(IUnitOfWork unitOfWork, AppDBContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
        [BindProperty]
        public Screen Screen { get; set; }
        //to be able to select cap from the database
        public List<Cap> Capacities { get; set; }

        public void OnGet()
        {
            Capacities = _unitOfWork.CapacityRepo.GetAll().ToList(); 
        }
        //public IActionResult OnPost(Screen screen)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _unitOfWork.ScreenRepo.Add(screen);
        //        _unitOfWork.Save();
        //    }

        //    return RedirectToPage("Index");
        //}

        public IActionResult OnPost(Screen screen)
        {
            // Check if the selected CapId exists in the Caps table
            var capExists = _dbContext.Caps.Any(c => c.Id == screen.CapId);

            if (!capExists)
            {
                // Handle error if the CapId does not exist
                ModelState.AddModelError("CapId", "The selected capacity does not exist.");
                return Page(); // Return to the page with the error message
            }

            // Add the screen if the CapId is valid
            _unitOfWork.ScreenRepo.Add(screen);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }



    }
}
    
