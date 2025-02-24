using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Row { get; set; }
        [Required]
        public int Column { get; set; }
        [Required]
        public string Type { get; set; }

        [Key]
        public int ScreenId { get; set; }
        public Screen? Screen { get; set; }
    }
}
