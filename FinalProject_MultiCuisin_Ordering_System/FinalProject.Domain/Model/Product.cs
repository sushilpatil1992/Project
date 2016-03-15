using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Model
{
    public class Product
    {
        public Product()
        {    }
        public int ProductId{ get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
 	        return base.ToString();
        }
       

    }
}
