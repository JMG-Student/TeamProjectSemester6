using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DataAccess.Repository
{
    public class ScreenRepo : Repository<Screen>, IScreenRepo
    {
        private readonly AppDBContext _dbContext;

        public ScreenRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public void Update(Screen screen)
        //{
        //    var filmFromDB = _dbContext.Screens.
        //        FirstOrDefault(filmFromDB => filmFromDB.Id == screen.Id);
        //    filmFromDB.Cap = screen.Cap;
        //}
    }
}

