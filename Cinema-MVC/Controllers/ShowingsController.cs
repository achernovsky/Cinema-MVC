using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.ViewModels;
using AjaxControlToolkit;

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
        public ActionResult Index()
        {
            var showings = _context.Showings.ToList();
            showings.ForEach(s =>
            {
                s.Movie = _context.Movies.SingleOrDefault(m => s.MovieId == m.Id);
                s.Theater = _context.Theaters.SingleOrDefault(t => s.TheaterId == t.Id);
            });
            var viewModel = new ShowingViewModel(showings);

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var theaters = _context.Theaters.ToList();
            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(theaters, movies, null);
            return View("MovieShowingForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var showing = _context.Showings.SingleOrDefault(s => s.Id == id);
            if (showing == null)
                return HttpNotFound();

            var theaters = _context.Theaters.ToList();
            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(theaters, movies, showing);
            return View("MovieShowingForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Showing showing)
        {
            if (showing.Id == 0)
            {
                var newShowing = new Showing()
                {
                    Theater = _context.Theaters.SingleOrDefault(s => s.Id == showing.TheaterId),
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

            var ticketsOrdered = _context.Tickets.Where(t => t.Showtime == showing.Showtime && t.TheaterId == showing.TheaterId).ToList();

            var theater = _context.Theaters.SingleOrDefault(m => m.Id == showing.TheaterId);
            var movie = _context.Movies.SingleOrDefault(m => m.Id == showing.MovieId);
            if (movie == null)
                return HttpNotFound();

            var ticket = new Ticket { Movie = movie, MovieId = movie.Id, Showtime = showing.Showtime, Theater = theater, TheaterId = theater.Id };

            var viewModel = new TicketsViewModel { Ticket = ticket, TicketsOrdered = ticketsOrdered, Showing = showing };
            return View(viewModel); 
        }

        [HttpPost]
        public ActionResult CompleteOrder(Ticket ticket)
        {
            if (ticket == null)
                return HttpNotFound();

            var seatsArray = ticket.SeatsList.Split(' ');
            var movie = _context.Movies.SingleOrDefault(m => m.Id == ticket.MovieId);
            var theater = _context.Theaters.SingleOrDefault(m => m.Id == ticket.TheaterId);

            List<Ticket> tickets = new List<Ticket>();

            for (int i = 0; i < seatsArray.Length - 1; i++)
            {
                var seat = seatsArray[i].Split(',');
                int rowNum = int.Parse(seat[0]);
                int seatNum = int.Parse(seat[1]);
                Ticket newTicket = new Ticket
                {
                    MovieId = movie.Id,
                    Movie = movie,
                    TheaterId = theater.Id,
                    Theater = theater,
                    rowNum = rowNum,
                    seatNum = seatNum,
                    Showtime = ticket.Showtime
                };
                _context.Tickets.Add(newTicket);
                tickets.Add(newTicket);
            };

            var viewModel = new CompleteOrderViewModel { Tickets = tickets, Movie = movie };
            _context.SaveChanges();

            TempData["ViewModel"] = viewModel;

            return Json(new
            {
                status = "Success",
                url = Url.Action("OrderSummary", "Showings", viewModel)
            });


  /*          return RedirectToAction("OrderSummary", "Showings", viewModel);*/
        }

        public ActionResult OrderSummary(CompleteOrderViewModel viewModel)
        {
            if (viewModel == null)
                return HttpNotFound();



            viewModel = (CompleteOrderViewModel)TempData["ViewModel"];

/*            return Json(new
            {
                status = "Success",
                url = Url.Action("OrderSummary", "Showings", viewModel)
            });

            return Json(viewModel, JsonRequestBehavior.AllowGet);*/

            return View(viewModel);
        }
    }
}