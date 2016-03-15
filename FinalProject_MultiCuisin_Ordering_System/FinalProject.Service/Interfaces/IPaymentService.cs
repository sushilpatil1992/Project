using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface IPaymentService
    {
        IList<Payment> GetPayments();
        Payment GetPaymentByID(int paymentId);
        int InsertPayment(Payment payment);
        int DeletePayment(int paymentId);
        int UpdatePayment(Payment payment);
        void Save();
       
    }
}
