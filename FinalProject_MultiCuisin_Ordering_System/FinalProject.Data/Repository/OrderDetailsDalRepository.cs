using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using SqlHelperLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Repository
{
    public class OrderDetailsDalRepository:IOrderDetailsRepository
    {
         public const string conString ="Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

         public OrderDetailsDalRepository()
         { }
         public IList<OrderDetails> GetOrderDetails()
         {
             List<OrderDetails> List = new List<OrderDetails>();
             SqlHelper sqlh = new SqlHelper(conString);
             string query = "Select * from OrderDetail";
             CommandType cmdtype = CommandType.Text;
             SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
             if (reader != null)
             {
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         OrderDetails item = new OrderDetails();
                         item.OdetailsId = int.Parse(reader["OdetailsId"].ToString());
                         item.OrderId = int.Parse(reader["OrderId"].ToString());
                         item.ProductId = int.Parse(reader["ProductId"].ToString());
                         item.Price = double.Parse(reader["Price"].ToString());
                         item.Quantity = int.Parse(reader["Quantity"].ToString());
                         List.Add(item);
                     }
                 }
             }
             return List;
         }

         public OrderDetails GetOrderDetailsById(int oDetailsId)
         {
             OrderDetails item = new OrderDetails();
             SqlHelper sqlh = new SqlHelper(conString);
             string query = "Select * from OrderDetail Where ODetailsId='@oDetailsId'";
             SqlParameter sqlParam1 = new SqlParameter("@oDetailsId", oDetailsId);
             CommandType cmdtype = CommandType.Text;
             SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype, sqlParam1);

             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     item.OdetailsId = int.Parse(reader["OdetailsId"].ToString());
                     item.OrderId = int.Parse(reader["OrderId"].ToString());
                     item.ProductId = int.Parse(reader["ProductId"].ToString());
                     item.Price = double.Parse(reader["Price"].ToString());
                     item.Quantity = int.Parse(reader["Quantity"].ToString());
                 }
                 reader.Close();
             }
             return item;
         }

         public int InsertOrderDetails(OrderDetails OrderDetails)
         {
             SqlHelper sqlh = new SqlHelper(conString);
             string query = "INSERT INTO OrderDetail(OrderId,ProductId,Price,Quantity) values (@orderId,@productId,@price,@quantity)";
             CommandType cmdtype = CommandType.Text;
             SqlParameter sqlParam1 = new SqlParameter("@orderId", OrderDetails.OrderId);
             SqlParameter sqlParam2 = new SqlParameter("@productId", OrderDetails.ProductId);
             SqlParameter sqlParam3 = new SqlParameter("@price", OrderDetails.Price);
             SqlParameter sqlParam4 = new SqlParameter("@quantity", OrderDetails.Quantity);
             int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1,sqlParam2,sqlParam3,sqlParam4);
             return status;
         }

         public int DeleteOrderDetails(int orderDetailsId)
         {

             SqlHelper sqlh = new SqlHelper(conString);
             string query = "Delete from OrderDetail where ODetailsId=@oDetailsId";
             CommandType cmdtype = CommandType.Text;
             SqlParameter sqlParam1 = new SqlParameter("@oDetailsId", orderDetailsId);
             int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
             return status;
         }

         public int UpdateOrderDetails(OrderDetails OrderDetails)
         {

             SqlHelper sqlh = new SqlHelper(conString);
             string query = " Update OrderDetail Set OrderId=@orderId,ProductId=@productId,Price=@price,Quantity=@quantity where ODetailsId=@oDetailsId";
             CommandType cmdtype = CommandType.Text;
             SqlParameter sqlParam1 = new SqlParameter("@orderId", OrderDetails.OrderId);
             SqlParameter sqlParam2 = new SqlParameter("@productId", OrderDetails.ProductId);
             SqlParameter sqlParam3 = new SqlParameter("@price", OrderDetails.Price);
             SqlParameter sqlParam4 = new SqlParameter("@quantity", OrderDetails.Quantity);
             SqlParameter sqlParam5 = new SqlParameter("@oDetailsId", OrderDetails.OdetailsId);
             int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3, sqlParam4, sqlParam5);
             return status;
         }

         public void Save()
         {
             throw new NotImplementedException();
         }
    }
}
