using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        { }
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage="Enter Title")]
        public string Title { get; set; }

        public override string ToString()
        {
 	        return base.ToString();
        }
        
    }
}
