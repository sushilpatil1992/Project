using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models

{
    public class Product
    {

        [Key]
        public int ProductId{ get; set; }
        [Required(ErrorMessage="Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please Add Description")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public double Price { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryViewModel categories{get; set;}

    }
}
