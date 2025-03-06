using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Films
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public Film Film { get; set; }

        public IEnumerable<SelectListItem> GenreList { get; set; }

        public void OnGet(int id)
        {
            Film = _unitOfWork.FilmRepo.Get(id);

            GenreList = _unitOfWork.GenreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost()
        {
            var filmFromDB = _unitOfWork.FilmRepo.Get(Film.Id);

            var files = HttpContext.Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                string wwwRootFolder = _webHostEnvironment.WebRootPath;
                string newFileName = Guid.NewGuid().ToString();
                var uploadPath = Path.Combine(wwwRootFolder, @"Images\Films");
                var extension = Path.GetExtension(files[0].FileName);

                if (!string.IsNullOrEmpty(filmFromDB.PosterLink))
                {
                    var oldFilePath = Path.Combine(wwwRootFolder, filmFromDB.PosterLink.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadPath, newFileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                Film.PosterLink = @"\Images\Films\" + newFileName + extension;
            }
            else
            {
                Film.PosterLink = filmFromDB.PosterLink;
            }

            filmFromDB.Title = Film.Title;
            filmFromDB.Description = Film.Description;
            filmFromDB.GenreId = Film.GenreId;
            filmFromDB.Runtime = Film.Runtime;

            ModelState.Remove("Film.PosterLink");

            if (!ModelState.IsValid)
            { 
                GenreList = _unitOfWork.GenreRepo.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                });
                return Page();
            }

            _unitOfWork.FilmRepo.Update(Film);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}