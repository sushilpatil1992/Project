using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Web.Service
{
    public class Cart
        {
        public List<OrderDetails> items = new List<OrderDetails>();
        public void Add(OrderDetails item)
            {
                items.Add(item);
            }
            public List<OrderDetails> Items
            {
                get
                {
                    return items;
                }
            }
            public double Total
            {
                get
                {
                    double total = 0;

                    foreach (OrderDetails item in items)
                    {
                        total += item.Amount;
                    }
                    return total;
                }
            }
        }    
}