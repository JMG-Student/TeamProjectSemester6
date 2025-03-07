using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.Models
{
    public class Cap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
