using CinemaProject.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmRepo FilmRepo { get; }

        void Save();
    }
}
