using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Screen
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int CapId { get; set; }
        public Cap? Cap { get; set; }

        public List<Seat>? Seats { get; set; }
    }
}
