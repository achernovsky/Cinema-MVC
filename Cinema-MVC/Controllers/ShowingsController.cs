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

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(movies, null);
            return View("MovieShowingForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var showing = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showing == null)
                return HttpNotFound();

            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(movies, showing);
            return View("MovieShowingForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Showing showing)
        {
            if (showing.Id == 0)
            {
                var newShowing = new Showing()
                {
                    Movie = _context.Movies.SingleOrDefault(s => s.Id == showing.MovieId),
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

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var showingInDB = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showingInDB == null)
                return HttpNotFound();

            _context.Showings.Remove(showingInDB);
            _context.SaveChanges();

            return RedirectToAction("", "Movies/Book/" + showingInDB.MovieId);
        }

        public ActionResult Book(int id)
        {
            var showing = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showing == null)
                return HttpNotFound();

            var ticketsOrdered = _context.Tickets.Where(t => t.Showtime == showing.Showtime).ToList();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == showing.MovieId);
            if (movie == null)
                return HttpNotFound();

            var ticket = new Ticket { Movie = movie, MovieId = movie.Id, Showtime = showing.Showtime };

            var viewModel = new TicketsViewModel { Ticket = ticket, TicketsOrdered = ticketsOrdered, Showing = showing };
            return View(viewModel); 
        }

        public ActionResult CompleteOrder(Ticket ticket)
        {
            var newTicket = new Ticket()
            {
                MovieId = ticket.MovieId,
                Movie = _context.Movies.SingleOrDefault(t => t.Id == ticket.MovieId),
                Showtime = ticket.Showtime,
                rowNum = ticket.rowNum,
                seatNum = ticket.seatNum
            };
            _context.Tickets.Add(newTicket);
            _context.SaveChanges();
            return View(newTicket);
        }
    }
}