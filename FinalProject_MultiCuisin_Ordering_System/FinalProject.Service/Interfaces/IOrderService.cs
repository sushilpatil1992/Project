using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface IOrderService
    {
        IList<Order> GetOrders();
        Order GetOrderByID(int orderId);
        int InsertOrder(Order order);
        int DeleteOrder(int orderId);
        int UpdateOrder(Order orderId);
        void Save();
       
    }
}
