using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacities
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Cap Cap { get; set; }
        public void OnGet(int id)
        {
            Cap = _unitOfWork.CapacityRepo.Get(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("", "Invalid ID provided.");
                return Page();
            }

            var capToUpdate = _unitOfWork.CapacityRepo.Get(id);

            if (capToUpdate == null)
            {
                ModelState.AddModelError("", $"Error: No capacity found with ID {id}.");
                return Page();
            }

            _unitOfWork.CapacityRepo.Update(capToUpdate);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }

    }
}