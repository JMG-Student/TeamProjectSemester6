using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Capacity
{
    public class CreateModel : PageModel
    {
            private readonly IUnitOfWork _unitOfWork;

            public CreateModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Cap cap { get; set; }
            public void OnGet()
            {
            }

            public IActionResult OnPost(Genre genre)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.GenreRepo.Add(genre);
                    _unitOfWork.Save();
                }
                return RedirectToPage("Index");
            }
    }
}
