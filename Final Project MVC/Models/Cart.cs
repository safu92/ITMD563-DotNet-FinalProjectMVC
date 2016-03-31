using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_MVC.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public virtual Product Product { get; set; }
    }
}