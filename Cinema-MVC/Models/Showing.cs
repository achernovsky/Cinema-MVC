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
        public virtual Movie Movie { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        public Showing()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
            if (SeatList == null)
            {
                SeatList = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            }
        }
    }
}