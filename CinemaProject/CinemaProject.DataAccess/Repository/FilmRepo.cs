using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
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

        public void Update(Film film)
        {
            var filmFromDB = _dbContext.Films.
                FirstOrDefault(filmFromDB => filmFromDB.Id == film.Id);
            filmFromDB.Title = film.Title;
            filmFromDB.GenreId = film.GenreId;
            filmFromDB.Runtime = film.Runtime;
            filmFromDB.Description = film.Description;
            if (film.PosterLink != null)
            {
                filmFromDB.PosterLink = film.PosterLink;
            }
        }

        //public IEnumerable<Film> GetAll()
        //{
        //    return _dbContext.Films
        //        .Include(a => a.Genre);
        //}
    }
}
