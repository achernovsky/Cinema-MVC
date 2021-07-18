using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Showing
    {
        public int Id { get; set; }
        public DateTime Showtime { get; set; }
        public List<int> SeatList { get; set; }
        public Movie Movie { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}