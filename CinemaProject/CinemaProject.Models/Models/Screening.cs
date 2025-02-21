using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }

        public DateTime Time { get; set; }

        // Foreign Key 
        public int ScreenID { get; set; }
        public Screen? Screen { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
