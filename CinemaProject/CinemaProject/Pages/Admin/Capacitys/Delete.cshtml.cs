using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacitys
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
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
                _unitOfWork.CapacityRepo.Delete(Cap);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}