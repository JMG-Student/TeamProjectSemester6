using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Cap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Capacity { get; set; }
        [Required]
    }
}
