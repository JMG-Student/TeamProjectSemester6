using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Services;

namespace CinemaProject.Pages.Admin.Films
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public Film Film { get; set; }
        public IEnumerable<SelectListItem> GenreList { get; set; }

        public void OnGet()
        {
            GenreList = _unitOfWork.GenreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }
        public IActionResult OnPost(Film film)
        {
            string mwmRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                ModelState.AddModelError("", "No file uploaded.");
                return Page();
            }

            string new_filename = Guid.NewGuid().ToString();
            var upload = Path.Combine(mwmRootFolder, @"Images\Films");
            var extension = Path.GetExtension(files[0].FileName);

            if (!Directory.Exists(upload))
            {
                Directory.CreateDirectory(upload);
            }

            using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            film.PosterLink = @"\Images\Films\" + new_filename + extension;

            if (!ModelState.IsValid)
            {
                _unitOfWork.FilmRepo.Add(film);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}