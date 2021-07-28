using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;

namespace Cinema_MVC.ViewModels
{
    public class ShowingViewModel
    {
        public List<Showing> Showings { get; set; }

        public ShowingViewModel(List<Showing> showings)
        {
            Showings = showings.OrderBy(s => s.Showtime).ToList();
        }
    }
}