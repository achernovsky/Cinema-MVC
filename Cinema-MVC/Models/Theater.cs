using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cinema_MVC.Models
{
    public class Theater
    {
        public int Id { get; set; }

        [Required()]
        [Display(Name = "Theater Number")]
        public int TheaterNum { get; set; }

        [Required()]
        [Display(Name = "Number of Rows")]
        public int NumOfRows { get; set; }

        [Required()]
        [Display(Name = "Number of Seats per Row")]
        public int NumOfSeatsPerRow { get; set; }
    }
}