using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema_MVC.Models;

namespace Cinema_MVC.ViewModels
{
    public class TicketsViewModel
    {
        public Showing Showing { get; set; }
        public Ticket Ticket { get; set; }
        public List<Ticket> TicketsOrdered { get; set; }
    }
}