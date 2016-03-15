using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Model
{
    class Feedback
    {
        public Feedback()
        {

        }
        public int FeedbackId { get; set; }
        public virtual int CustomerId { get; set; }
        public string Feedbacks { get; set; }
    }
}
