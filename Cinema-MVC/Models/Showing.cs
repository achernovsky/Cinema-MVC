﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cinema_MVC.Models
{
    public class Showing
    {
        public int Id { get; set; }

        [Required]
        public DateTime Showtime { get; set; }

        public Movie Movie { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        public int numOfRows { get; set; }
        public int numOfSeatsPerRow { get; set; }

        public Showing()
        {
            numOfRows = 8;
            numOfSeatsPerRow = 16;
        }
    }
}