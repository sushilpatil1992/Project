﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Model
{
    public class OrderDetails
    {
        public OrderDetails()
        { }
        public int OdetailsId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set;}
        public  int OrderId { get; set;}
        public double Amount { get; set; }

    }
}
