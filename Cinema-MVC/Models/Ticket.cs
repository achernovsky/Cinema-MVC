using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public DateTime Showtime { get; set; }
        public int rowNum { get; set; }
        public int seatNum { get; set; }
        public string SeatsList { get; set; }
        public Theater Theater { get; set; }
    }
}