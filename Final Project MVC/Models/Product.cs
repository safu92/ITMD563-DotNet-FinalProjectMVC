using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_MVC.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Price { get; set; }
    }
}