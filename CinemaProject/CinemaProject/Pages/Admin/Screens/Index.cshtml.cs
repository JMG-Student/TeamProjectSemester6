using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Services;

namespace CinemaProject.Pages.Admin.Screens
{

    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Screen> screens;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            screens = _unitOfWork.ScreenRepo.GetAll();
        }
    }
}


//public class IndexModel : PageModel
//{
//private readonly AppDBContext _dbContext;
//public IEnumerable<Models.Models.Screen> Screens;
//public IndexModel(AppDBContext dBContext)
//{
//    _dbContext = dBContext;
//}
//        public void OnGet()
//        {
//            Screens = _dbContext.Screens;
//        }
//    }
//}
