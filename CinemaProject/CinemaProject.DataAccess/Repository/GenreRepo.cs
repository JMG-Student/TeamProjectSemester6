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
    public class GenreRepo : Repository<Genre>, IGenreRepo
    {
        private readonly AppDBContext _dbContext;
        public GenreRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _dbContext.Genres
                .Include(a => a.Films)
                .ToList();
        }
    }
}