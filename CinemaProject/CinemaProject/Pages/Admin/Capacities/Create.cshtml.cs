//using CinemaProject.Models.Models;
//using CinemaProject.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace CinemaProject.Pages.Admin.Capacities
//{

//    [BindProperties]
//    public class CreateModel : PageModel
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateModel(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        [BindProperty]
//        public Cap Cap { get; set; }

//        public void OnGet()
//        {
//        }

//        public IActionResult OnPost(Cap cap)
//        {
//            if (ModelState.IsValid)
//            {
//                _unitOfWork.CapacityRepo.Add(cap);
//                _unitOfWork.Save();
//            }
//            return RedirectToPage("Index");
//        }
//    }
//}
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
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [BindProperty]
        public Cap Cap { get; set; } = new Cap();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_unitOfWork.CapacityRepo == null)
            {
                throw new NullReferenceException("CapacityRepo is NULL. Ensure it's registered in UnitOfWork.");
            }

            _unitOfWork.CapacityRepo.Add(Cap);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}




