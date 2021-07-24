using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;

namespace Cinema_MVC.ViewModels
{
    public class MovieShowingViewModel
    {
        public List<Theater> Theaters;
        public List<Movie> Movies;
        public Showing Showing;
        public MovieShowingViewModel() { }
        public MovieShowingViewModel(List<Theater> theaters, List<Movie> movies, Showing showing)
        {
            Theaters = theaters;
            Movies = movies;
            Showing = showing;
        }
    }
}