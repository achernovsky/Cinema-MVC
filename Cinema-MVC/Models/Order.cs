using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice
        {
            get
            {
                return Tickets.Sum(t => t.Price);
            }
        }
        public virtual List<Ticket> Tickets { get; set; }
        public virtual User User { get; set; }
        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
    }
}