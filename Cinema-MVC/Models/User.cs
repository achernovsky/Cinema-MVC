using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; }

        public User()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }
    }
}