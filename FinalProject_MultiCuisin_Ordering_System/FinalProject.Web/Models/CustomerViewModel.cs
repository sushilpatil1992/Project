using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Ioc;
namespace FinalProject.Web.Models
{
    public class CustomerViewModel
    {
        
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50,ErrorMessage="First Name must be less than 50 characters ")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(50,ErrorMessage="Last Name must be less than 50 characters ")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [StringLength(150,ErrorMessage="Adress must be less than 50 characters ")]
        public string Adress { get; set; }
        public virtual ApplicationUser user{ get; set; }
        public string ApplicationUserId { get; set; }
    }
}
