using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacity
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

        public IActionResult OnPost(Cap cap)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CapacityRepo.Update(Cap);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}