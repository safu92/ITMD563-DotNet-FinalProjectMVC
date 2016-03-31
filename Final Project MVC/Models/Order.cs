using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_MVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}