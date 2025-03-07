using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Models.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ScreeningId { get; set; }
        [ForeignKey("ScreeningId")]
        public Screening Screening { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int SeatId { get; set; } 
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }  

        [Required]
        public decimal Price { get; set; } // ✅ Add this if missing

        [Required]
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }

}
