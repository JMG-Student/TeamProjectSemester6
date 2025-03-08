using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacities
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Cap Cap { get; set; }

        public IActionResult OnPost(Cap cap)
        {
            if (!ModelState.IsValid)
            {
                _unitOfWork.CapacityRepo.Add(cap);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}




