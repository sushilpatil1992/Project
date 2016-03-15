using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models
{
    class Rating
    {
        public Rating()
        { }

        public int RatingId { get; set; }
        public virtual int ProductId { get; set; }

        public virtual int UserId { get; set; }
        public int Ratings { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
