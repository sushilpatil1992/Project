using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Interfaces
{
    public interface IPaymentRepository
    {
        IList<Payment> GetPayment();
        Payment GetPaymentById(int paymentId);
        int InsertPayment(Payment payment);
        int DeletePayment(int paymentId);
        int UpdatePayment(Payment payment);
        void Save();
    }
}
