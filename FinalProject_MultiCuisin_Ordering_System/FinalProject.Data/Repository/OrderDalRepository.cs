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
    public class OrderDalRepository:IOrderRepository
    {
        public const string conString = "Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

        public OrderDalRepository()
        { }
        public IList<Order> GetOrder()
        {
            List<Order> List = new List<Order>();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from [Order]";
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order item = new Order();
                        item.OrderId = int.Parse(reader["OrderId"].ToString());
                        item.Amount = double.Parse(reader["Amount"].ToString());
                        item.CustomerId = int.Parse(reader["CustomerId"].ToString());
                        item.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                        List.Add(item);
                    }
                }
            }
            return List;
        }

        public Order GetOrderById(int orderId)
        {
            Order item = new Order();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from [Order] Where OrderId=@orderId";
            SqlParameter sqlParam1 = new SqlParameter("@orderId", orderId);
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype, sqlParam1);


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item.OrderId = int.Parse(reader["OrderId"].ToString());
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.CustomerId =int.Parse(reader["CustomerId"].ToString());
                    item.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
                }
            }
            return item;
        }

        public int InsertOrder(Order Order)
        {
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Insert into [Order](Amount,CustomerId,OrderDate) values (@amount,@customerId,@orderDate)";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@amount", Order.Amount);
            SqlParameter sqlParam2 = new SqlParameter("@customerId", Order.CustomerId);
            SqlParameter sqlParam3 = new SqlParameter("@orderDate", (DateTime)Order.OrderDate);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3);
            return status;
        }

        public int DeleteOrder(int orderId)
        {

            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Delete from [Order] where OrderId=@orderId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@orderId", orderId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
            return status;
        }

        public int UpdateOrder(Order Order)
        {

            SqlHelper sqlh = new SqlHelper(conString);
            string query = " Update [Order] Set Amount=@amount,OrderDate=@orderDate where OrderId=@orderId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@amount", Order.Amount);
            SqlParameter sqlParam2 = new SqlParameter("@orderDate", Order.OrderDate);
            SqlParameter sqlParam3 = new SqlParameter("@orderId", Order.OrderId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3);
            return status;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


       
    }
}
