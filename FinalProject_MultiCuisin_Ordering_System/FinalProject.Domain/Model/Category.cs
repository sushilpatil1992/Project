using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Model
{
    public class Category
    {
        public Category()
        { }
        public int CategoryId { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
 	        return base.ToString();
        }
        
    }
}
