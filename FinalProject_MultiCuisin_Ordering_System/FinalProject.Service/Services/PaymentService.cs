using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class PaymentService:IPaymentService
    {
        private readonly IPaymentRepository _PaymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _PaymentRepository = paymentRepository;
        }
        public IList<Payment> GetPayments()
        {
            return _PaymentRepository.GetPayment();
        }

        public Payment GetPaymentByID(int paymentId)
        {
            return _PaymentRepository.GetPaymentById(paymentId);
        }

        public int InsertPayment(Payment payment)
        {
            int status = _PaymentRepository.InsertPayment(payment);
            return status;
        }

        public int DeletePayment(int paymentId)
        {
            int status = _PaymentRepository.DeletePayment(paymentId);
            return status;
        }

        public int UpdatePayment(Payment payment)
        {
            int status = _PaymentRepository.UpdatePayment(payment);
            return status;
        }

        public void Save()
        {
            _PaymentRepository.Save();
        }
    }
}
