using CinemaProject.DataAccess;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class FilmService
    {
        private readonly AppDBContext _context;

        public FilmService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film?> GetFilmByIdAsync(int filmId)
        {
            return await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);
        }
    }
}
