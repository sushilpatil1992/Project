using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Model
{
    public class Order
    {
        public Order()
        {

        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public List<OrderDetails> Items { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
