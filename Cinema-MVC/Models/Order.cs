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
        public List<Ticket> Tickets { get; set; }
        public User User { get; set; }
        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
    }
}