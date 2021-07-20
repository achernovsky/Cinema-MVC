using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;
using Cinema_MVC.Dtos;
using Cinema_MVC.ViewModels;
using AutoMapper;

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
            var moviesDtos = movies.Select(Mapper.Map<Movie, MovieDto>).ToList();
            var viewModel = new MoviesViewModel()
            {
                Movies = moviesDtos
            };
            return View(viewModel);
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return View(movieDto);
        }

        public ActionResult Book(int id)
        {
            return View();
        }

        public ActionResult New()
        {
            var movie = new MovieDto();
            return View("MovieForm",movie);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return View("MovieForm", movieDto);

            if(movieDto.Id == 0)
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movieDto.Id);
                Mapper.Map(movieDto, movieInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return View("MovieForm", movieDto);
        }

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