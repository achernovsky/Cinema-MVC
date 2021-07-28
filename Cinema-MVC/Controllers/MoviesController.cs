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

        public ActionResult List()
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
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            if (User.IsInRole("Admin"))
                return View(movie);
            else
                return View("LimitedAccessDetails", movie);
        }

        public ActionResult Book(int id)
        {
            ShowingViewModel viewModel;
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            else
                viewModel = new ShowingViewModel(_context.Showings.Where(m => m.MovieId == id).ToList());

            foreach (Showing element in viewModel.Showings)
            {
                element.Movie = _context.Movies.SingleOrDefault(m => m.Id == element.MovieId);
                element.Theater = _context.Theaters.SingleOrDefault(m => m.Id == element.TheaterId);
            }
            if (User.IsInRole("Admin"))
                return View(viewModel);
            else
                return View("LimitedAccessBook", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var movie = new Movie();
            return View("MovieForm",movie);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
                return View("MovieForm", movie);

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Description = movie.Description;
                movieInDb.ImageUrl = movie.ImageUrl;
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View("MovieForm", movie);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("", "Movies");
        }
    }
}