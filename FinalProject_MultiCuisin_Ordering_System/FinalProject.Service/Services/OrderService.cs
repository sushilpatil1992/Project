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
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }
        public IList<Order> GetOrders()
        {
            return _OrderRepository.GetOrder();
        }

        public Order GetOrderByID(int orderId)
        {
            return _OrderRepository.GetOrderById(orderId);
        }

        public int InsertOrder(Order order)
        {
            int status = _OrderRepository.InsertOrder(order);
            return status;
        }

        public int DeleteOrder(int orderId)
        {
            int status = _OrderRepository.DeleteOrder(orderId);
            return status;
        }

        public int UpdateOrder(Order order)
        {
            int status = _OrderRepository.UpdateOrder(order);
            return status;
        }

        public void Save()
        {
            _OrderRepository.Save();
        }
    }
}
