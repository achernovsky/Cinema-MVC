using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace Cinema_MVC.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Showing> Showings { get; set; }
    }
}