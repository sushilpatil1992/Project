using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {

        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
