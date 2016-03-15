using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models
{
    public class OrderDetails
    {
        public double amount;
        public OrderDetails()
        { }
        public int OdetailsId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set;}
        public  int OrderId { get; set;}
        public double Amount {
           
           
            set{
                amount = Price * Quantity;
               }
            get
            {
                return amount;
            }
           }

    }
}
