using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface IOrderDetailsService
    {
        IList<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetailsByID(int oDetailsId);
        int InsertOrderDetails(OrderDetails orderDetails);
        int DeleteOrderDetails(int oDetailsId);
        int UpdateOrderDetails(OrderDetails orderDetails);
        void Save();
       
    }
}
