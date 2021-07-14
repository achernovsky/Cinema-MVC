using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int NumOfTickets { get; set; }
    }
}