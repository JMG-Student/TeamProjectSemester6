using CinemaProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DataAccess.Repository
{
    public interface ICapacityRepo : IRepository<Cap>
    {
        public void Update(Cap Cap);
    }
}
