﻿using System;
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
        //have it set to defaukt cap of 120
        [Required]
        public int Cap { get; set; } = 120;


        //public List<Seat>? Seats { get; set; }
    }
}
