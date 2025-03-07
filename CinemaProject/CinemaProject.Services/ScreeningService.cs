using CinemaProject.DataAccess.DataAccess;
using CinemaProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class ScreeningService
    {
        private readonly AppDBContext _context;

        public ScreeningService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Screening>> GetScreeningsByFilmIdAsync(int filmId)

        {
            return await _context.Screenings.Where(s => s.FilmID == filmId).ToListAsync();
        }
    }
}
