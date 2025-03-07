using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;


namespace CinemaProject.Pages.Admin.Capacity
{
    [BindProperties]
    public class CapacityCreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CapacityCreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Cap Cap { get; set; }

        public void OnGet()
        {
            Cap = new Cap();
        }

        public IActionResult OnPost(Cap cap)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CapacityRepo.Add(cap);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}