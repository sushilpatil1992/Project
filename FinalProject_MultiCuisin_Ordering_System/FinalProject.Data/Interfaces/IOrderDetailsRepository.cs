using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IList<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetailsById(int oDetailsId);
        int InsertOrderDetails(OrderDetails oDetailsId);
        int DeleteOrderDetails(int oDetailsId);
        int UpdateOrderDetails(OrderDetails oDetailsId);
        void Save();
    }
}
