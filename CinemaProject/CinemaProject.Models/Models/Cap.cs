using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.Models
{
    public class Cap
    {
        [Key]
        public int Id { get; set; }


        public int? Capacity { get; set; }
    }
}
