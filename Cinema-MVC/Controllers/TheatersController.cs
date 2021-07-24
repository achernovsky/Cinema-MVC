using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.ViewModels;

namespace Cinema_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TheatersController : Controller
    {
        private ApplicationDbContext _context;

        public TheatersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var theaters = _context.Theaters.ToList();

            var viewModel = new TheatersViewModel()
            {
                Theaters = theaters
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var theater = _context.Theaters.SingleOrDefault(m => m.Id == id);
            if (theater == null)
                return HttpNotFound();

            return View(theater);
        }
        public ActionResult New()
        {
            var theater = new Theater();
            return View("TheaterForm", theater);
        }

        public ActionResult Save(Theater theater)
        {
            if (!ModelState.IsValid)
                return View("TheaterForm", theater);

            if (theater.Id == 0)
            {
                _context.Theaters.Add(theater);
            }
            else
            {
                var theaterInDb = _context.Theaters.Single(m => m.Id == theater.Id);
                theaterInDb.TheaterNum = theater.TheaterNum;
                theaterInDb.NumOfRows = theater.NumOfRows;
                theaterInDb.NumOfSeatsPerRow = theater.NumOfSeatsPerRow;
            }
            _context.SaveChanges();
            return RedirectToAction("", "Theaters");
        }

        public ActionResult Edit(int id)
        {
            var theater = _context.Theaters.SingleOrDefault(m => m.Id == id);
            if (theater == null)
                return HttpNotFound();

            return View("TheaterForm", theater);
        }

        public ActionResult Delete(int id)
        {
            var theater = _context.Theaters.SingleOrDefault(m => m.Id == id);
            if (theater == null)
                return HttpNotFound();

            _context.Theaters.Remove(theater);
            _context.SaveChanges();

            return RedirectToAction("", "Theaters");
        }
    }
}