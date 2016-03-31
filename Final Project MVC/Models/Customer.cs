﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_MVC.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}