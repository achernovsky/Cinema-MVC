using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Seat { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Showing Showing { get; set; }
    }
}