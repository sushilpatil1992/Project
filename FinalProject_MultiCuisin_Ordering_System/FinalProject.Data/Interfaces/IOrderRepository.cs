using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Domain.Model;
namespace FinalProject.Data.Interfaces
{
    public interface IOrderRepository
    {
        IList<Order> GetOrder();
        Order GetOrderById(int orderId);
        int InsertOrder(Order order);
        int DeleteOrder(int orderId);
        int UpdateOrder(Order order);
        void Save();
    }
}
