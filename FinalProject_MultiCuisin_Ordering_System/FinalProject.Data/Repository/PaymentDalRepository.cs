
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
    public class PaymentDalRepository:IPaymentRepository
    {
         public const string conString ="Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

        public PaymentDalRepository()
        { }
        public IList<Payment> GetPayment()
        {
            List<Payment> List = new List<Payment>();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Payment";
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Payment item = new Payment();
                        item.PaymentId = int.Parse(reader["PaymentId"].ToString());
                        item.Amount = double.Parse(reader["Amount"].ToString());
                        item.Date = DateTime.Parse(reader["PaymentDate"].ToString());
                        item.OrderId = int.Parse(reader["OrderId"].ToString());
                        item.PaymentMode = (PaymentMode)(int.Parse(reader["PaymentMode"].ToString()));
                        List.Add(item);
                    }
                }
            }
            return List;
        }

        public Payment GetPaymentById(int paymentId)
        {
            Payment item = new Payment();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Payment Where PaymentId=@paymentId";
            SqlParameter sqlParam1 = new SqlParameter("@paymentId", paymentId);
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype, sqlParam1);


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item.PaymentId = int.Parse(reader["PaymentId"].ToString());
                    item.Amount = double.Parse(reader["Amount"].ToString());
                    item.Date = DateTime.Parse(reader["PaymentDate"].ToString());
                    item.OrderId = int.Parse(reader["OrderId"].ToString());
                    item.PaymentMode = (PaymentMode)(int.Parse(reader["PaymentMode"].ToString()));
                }
            }
            return item;
        }

        public int InsertPayment(Payment Payment)
        {
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "INSERT INTO Payment(Amount,OrderId,PaymentDate,PaymentMode) values (@amount,@orderId,@paymentDate,@paymentMode)";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@amount", Payment.Amount);
            SqlParameter sqlParam2 = new SqlParameter("@paymentDate", Payment.Date);
            SqlParameter sqlParam3 = new SqlParameter("@orderId", Payment.OrderId);
            SqlParameter sqlParam4 = new SqlParameter("@paymentMode", Payment.PaymentMode);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3, sqlParam4);
            return status;
        }

        public int DeletePayment(int paymentId)
        {

            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Delete from Payment where PaymentId=@paymentId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@paymentId", paymentId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
            return status;
        }

        public int UpdatePayment(Payment payment)
        {

            SqlHelper sqlh = new SqlHelper(conString);
            string query = " Update Payment Set Amount=@amount,PaymentDate=@paymentDate,OrderId=@orderId where PaymentId=@paymentId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@amount", payment.Amount);
            SqlParameter sqlParam2 = new SqlParameter("@paymentDate", payment.Date);
            SqlParameter sqlParam3 = new SqlParameter("@orderId", payment.OrderId);
            SqlParameter sqlParam4 = new SqlParameter("@paymentId", payment.PaymentId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3,sqlParam4);
            return status;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


    }
}
