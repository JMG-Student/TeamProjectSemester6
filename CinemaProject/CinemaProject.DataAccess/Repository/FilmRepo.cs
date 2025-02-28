using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DataAccess.Repository
{
    public class FilmRepo : Repository<Film> , IFilmRepo
    {
        private readonly AppDBContext _dbContext;

        public FilmRepo(AppDBContext dbContext) : base (dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
