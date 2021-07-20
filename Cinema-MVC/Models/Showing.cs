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
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int numOfRows { get; set; }
        public int numOfSeatsPerRow { get; set; }
        public Showing(int rows, int seats)
        {
            numOfRows = rows;
            numOfSeatsPerRow = seats;
        }
    }
}