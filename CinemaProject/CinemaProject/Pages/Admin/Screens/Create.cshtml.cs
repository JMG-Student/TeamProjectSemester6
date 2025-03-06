using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.Models.Models;
using CinemaProject.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaProject.Pages.Admin.Screens
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Screen Screen { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost(Screen screen)
        { 
            if (!ModelState.IsValid)
            {
                _unitOfWork.ScreenRepo.Add(Screen); 
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}
    //public class CreateModel : PageModel
    //{

    //    private readonly AppDBContext _dbContext;

    //    [BindProperty]
    //    public Screen Screen { get; set; } = new Screen();

    //    public CreateModel(AppDBContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public void OnGet()
    //    {
    //    }
    //    public IActionResult OnPost(Film film)
    //    {
    //        string mwmRootFolder = _webHostEnvironment.WebRootPath;
    //        var files = HttpContext.Request.Form.Files;

    //        if (files == null || files.Count == 0)
    //        {
    //            ModelState.AddModelError("", "No file uploaded.");
    //            return Page();
    //        }

    //        string new_filename = Guid.NewGuid().ToString();
    //        var upload = Path.Combine(mwmRootFolder, @"Images\Films");
    //        var extension = Path.GetExtension(files[0].FileName);

    //        if (!Directory.Exists(upload))
    //        {
    //            Directory.CreateDirectory(upload);
    //        }

    //        using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
    //        {
    //            files[0].CopyTo(fileStream);
    //        }

    //        film.PosterLink = @"\Images\Films\" + new_filename + extension;

    //        if (!ModelState.IsValid)
    //        {
    //            _unitOfWork.FilmRepo.Add(film);
    //            _unitOfWork.Save();
    //        }

    //        return RedirectToPage("Index");
    //    }
    //}

