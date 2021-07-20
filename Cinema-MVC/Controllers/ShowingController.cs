using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.ViewModels;

namespace Cinema_MVC.Controllers
{
    public class ShowingController : Controller
    {
        private ApplicationDbContext _context;

        public ShowingController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MovieShowingViewModel(movies, null);
            return View("MovieShowingForm", viewModel);
        }
/*        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedule.SingleOrDefault(s => s.ID == id);
            if (schedule == null)
                return View("", "Auditorium");
            var movies = _context.Movies.ToList();
            var auditoriums = _context.Auditoriums.ToList();
            var viewModel = new ScheduleMovieViewModel(auditoriums, movies, schedule);
            return View("ScheduleMovieForm", viewModel);
        }*/
/*        public ActionResult Save(ScheduledMovie schedule)
        {
            if (schedule.ID == 0)
            {
                var newSchedule = new ScheduledMovie()
                {
                    Auditorium = _context.Auditoriums.SingleOrDefault(a => a.ID == schedule.AuditoriumId),
                    Movie = _context.Movies.SingleOrDefault(m => m.ID == schedule.MovieID),
                    ScreeningTime = schedule.ScreeningTime
                };
                _context.Schedule.Add(newSchedule);
            }
            else
            {
                var scheduleInDb = _context.Schedule.SingleOrDefault(s => s.ID == schedule.ID);
                _context.Entry(scheduleInDb).CurrentValues.SetValues(schedule);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }*/
/*        public ActionResult Delete(int id)
        {
            var scheduleInDB = _context.Schedule.SingleOrDefault(s => s.ID == id);
            if (scheduleInDB == null)
                return NotFound();

            _context.Remove(scheduleInDB);
            _context.SaveChanges();

            return RedirectToAction("", "Schedule");
        }*/
    }
}