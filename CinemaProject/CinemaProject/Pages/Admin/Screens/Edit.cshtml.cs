using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Screens
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Screen Screen { get; set; }
        public void OnGet(int id)
        {
            Screen = _unitOfWork.ScreenRepo.Get(id);
        }

        public IActionResult OnPost(Screen screen)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ScreenRepo.Update(screen);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}