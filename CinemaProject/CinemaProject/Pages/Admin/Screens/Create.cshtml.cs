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

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Screen Screen { get; set; }
        //to be ablwe to select cap from the database
        public List<Cap> Capacities { get; set; }

        public void OnGet()
        {
            Capacities = _unitOfWork.CapacityRepo.GetAll().ToList(); 
        }
        public IActionResult OnPost(Screen screen)
        {
            if (!ModelState.IsValid)
            {
                _unitOfWork.ScreenRepo.Add(screen); 
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }

    }
}
    
