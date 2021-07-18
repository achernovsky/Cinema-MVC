using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.ViewModels;

namespace Cinema_MVC.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>()
        {
            new Movie() { Id = 1, Name = "Black Widow", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac dapibus justo, quis convallis nibh.",
            ImageUrl = "https://hotcinema.co.il/images/BLACK-WIDOW.JPG?w=314&h=451&mode="},
            new Movie() { Id = 2, Name = "Space Jam", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac dapibus justo, quis convallis nibh.",
            ImageUrl = "https://hotcinema.co.il/images/spaceJam_New.jpg?w=314&h=451&mode="}
        };
        public ActionResult Index()
        {
            var viewModel = new MoviesVievModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            if (id >= movies.Count)
                return HttpNotFound();

            var movie = movies[id - 1];
            return View(movie);
        }

        public ActionResult Book(int id)
        {
            return View();
        }
    }
}