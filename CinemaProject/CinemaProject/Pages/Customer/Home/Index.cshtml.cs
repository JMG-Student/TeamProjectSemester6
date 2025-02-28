using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

         public IEnumerable<Film> listOfFilms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            listOfFilms = _unitOfWork.FilmRepo.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfFilms= listOfFilms.Where(p => p.Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
