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
    public class OrderDetailsService : IOrderDetailsService

    {
        private readonly IOrderDetailsRepository _OrderDetailsRepository;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _OrderDetailsRepository = orderDetailsRepository;
        }
        public IList<OrderDetails> GetOrderDetails()
        {
            return _OrderDetailsRepository.GetOrderDetails();
        }

        public OrderDetails GetOrderDetailsByID(int oDetailsId)
        {
            return _OrderDetailsRepository.GetOrderDetailsById(oDetailsId);
        }

        public int InsertOrderDetails(OrderDetails orderDetails)
        {
            int status = _OrderDetailsRepository.InsertOrderDetails(orderDetails);
            return status;
        }

        public int DeleteOrderDetails(int oDetailsId)
        {
            int status = _OrderDetailsRepository.DeleteOrderDetails(oDetailsId);
            return status;
        }

        public int UpdateOrderDetails(OrderDetails orderDetails)
        {
            int status = _OrderDetailsRepository.UpdateOrderDetails(orderDetails);
            return status;
        }

        public void Save()
        {
            _OrderDetailsRepository.Save();
        }


    }
}
