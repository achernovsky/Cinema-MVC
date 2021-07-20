using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.ViewModels;

namespace Cinema_MVC.Controllers
{
    public class ShowingsController : Controller
    {
        private ApplicationDbContext _context;

        public ShowingsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(movies, null);
            return View("MovieShowingForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var showing = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showing == null)
                return HttpNotFound();

            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(movies, showing);
            return View("MovieShowingForm", viewModel);
        }
        public ActionResult Save(Showing showing)
        {
            if (showing.Id == 0)
            {
                var newShowing = new Showing()
                {
                    Movie = _context.Movies.SingleOrDefault(m => m.Id == showing.MovieId),
                    Showtime = showing.Showtime
                };
                _context.Showings.Add(newShowing);
            }
            else
            {
                var showingInDb = _context.Showings.SingleOrDefault(s => s.Id == showing.Id);
                _context.Entry(showingInDb).CurrentValues.SetValues(showing);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies/Book/" + showing.MovieId);
        }
        public ActionResult Delete(int id)
        {
            var showingInDB = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showingInDB == null)
                return HttpNotFound();

            _context.Showings.Remove(showingInDB);
            _context.SaveChanges();

            return RedirectToAction("", "Movies/Book/" + showingInDB.MovieId);
        }
    }
}