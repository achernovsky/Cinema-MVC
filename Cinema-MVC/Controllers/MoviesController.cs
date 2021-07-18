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
        /*        private List<Movie> movies = new List<Movie>()
                {
                    new Movie() { Id = 1, Name = "Black Widow", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac dapibus justo, quis convallis nibh. Proin quis luctus nulla. Vivamus bibendum pellentesque consequat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam feugiat dui libero. Nam dui sem, laoreet et tellus sit amet, pretium finibus tellus. Etiam efficitur nec arcu vel vestibulum. Vestibulum ex nibh, tempor ut tempus a, consequat eget sem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac dapibus justo, quis convallis nibh. Proin quis luctus nulla. Vivamus bibendum pellentesque consequat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam feugiat dui libero. Nam dui sem, laoreet et tellus sit amet, pretium finibus tellus. Etiam efficitur nec arcu vel vestibulum. Vestibulum ex nibh, tempor ut tempus a, consequat eget sem. ",
                    ImageUrl = "https://hotcinema.co.il/images/BLACK-WIDOW.JPG?w=314&h=451&mode="},
                    new Movie() { Id = 2, Name = "Space Jam", Description = "Cras at nisl sed augue faucibus blandit. Suspendisse euismod pretium vehicula. Pellentesque lectus enim, dignissim sit amet congue sit amet, eleifend ut ligula. Vestibulum in rhoncus massa. Curabitur vitae ligula quis augue congue condimentum. Duis ut rutrum metus, eget iaculis nunc. Donec semper lorem sed ornare consequat. In tincidunt in dui a bibendum. Nam ultrices sagittis odio, non condimentum ex pharetra non. ",
                    ImageUrl = "https://hotcinema.co.il/images/spaceJam_New.jpg?w=314&h=451&mode="}
                };*/
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MoviesViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
/*            if (id > movies.Count)
                return HttpNotFound();

            var movie = movies[id - 1];*/
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            
            return View(movie);
        }

        public ActionResult Book(int id)
        {
            return View();
        }
    }
}