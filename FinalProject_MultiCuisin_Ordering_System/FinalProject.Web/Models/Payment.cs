using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Web.Models
{
    public enum PaymentMode
    {
        CreditCard, DebitCard, NetBanking,CashOnDelivery
    }
    public class Payment
    {
        public Payment()
        { }
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public  int OrderId { get; set;}
    }
}
