using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema_MVC.Models;

namespace Cinema_MVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Black Widow" };
            return View(movie);
        }
    }
}