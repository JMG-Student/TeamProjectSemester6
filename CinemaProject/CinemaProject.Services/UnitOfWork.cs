using CinemaProject.DataAccess;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;

        public IFilmRepo FilmRepo { get; private set; }

        public IGenreRepo GenreRepo { get; private set; }

        public IScreenRepo ScreenRepo { get; private set; }

        public ICapacityRepo CapacityRepo { get; private set; }

        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            FilmRepo = new FilmRepo(_dbContext);
            GenreRepo = new GenreRepo(_dbContext);
            ScreenRepo = new ScreenRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
