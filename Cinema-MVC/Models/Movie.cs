using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Showing> Showings { get; set; }

        public Movie()
        {
            if (Showings == null)
            {
                Showings = new List<Showing>();
            }
        }

        public Movie(String MovieName)
        {
            if (Showings == null)
            {
                Showings = new List<Showing>();
            }

            Name = MovieName;
        }
    }
}