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
        public int TheaterNum { get; set; }

        [Required()]
        public int NumOfRows { get; set; }

        [Required()]
        public int NumOfSeatsPerRow { get; set; }
    }
}