using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;

namespace Cinema_MVC.ViewModels
{
    public class CompleteOrderViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public Movie Movie { get; set; }
    }
}