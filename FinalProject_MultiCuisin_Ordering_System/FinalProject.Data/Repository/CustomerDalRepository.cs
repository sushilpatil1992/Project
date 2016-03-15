using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Domain.Model;
using System.Data.SqlClient;
using System.Data;
using SqlHelperLibrary;
using FinalProject.Data.Interfaces;
namespace FinalProject.Data.Repository
{
    public class CustomerDalRepository :ICustomerRepository
    {
        public const string conString ="Data Source=DESKTOP-NBMCBR7\\SQLEXPRESS;Initial Catalog=MulticuisinDb;Integrated Security=True";

        public CustomerDalRepository()
        { }
        public IList<Customer> GetCustomers()
        {
            List<Customer> List = new List<Customer>();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Customer";
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype);
            if(reader!=null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer item = new Customer();
                        item.CustomerId = int.Parse(reader["CustomerId"].ToString());
                        item.FirstName = reader["FirstName"].ToString();
                        item.LastName = reader["LastName"].ToString();
                        item.Adress = reader["Adress"].ToString();
                        item.UserId = reader["UserId"].ToString();
                        List.Add(item);
                    }
                }
            }
            return List;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer item = new Customer();
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Select * from Customer Where CustomerId=@customerId";
            SqlParameter sqlParam1 = new SqlParameter("@customerId", customerId);
            CommandType cmdtype = CommandType.Text;
            SqlDataReader reader = sqlh.ExecuteReader(query, cmdtype,sqlParam1);


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    item.CustomerId = int.Parse(reader["CustomerId"].ToString());
                    item.FirstName = reader["FirstName"].ToString();
                    item.LastName = reader["LastName"].ToString();
                    item.Adress = reader["Adress"].ToString();
                    item.UserId = reader["UserId"].ToString();
                }
            }
            return item;
        }

        public int InsertCustomer(Customer customer)
        {
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "INSERT INTO Customer(FirstName,LastName,Adress,UserId) values (@firstName,@lastName,@adress,@userId)";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@firstName", customer.FirstName);
            SqlParameter sqlParam2 = new SqlParameter("@lastName", customer.LastName);
            SqlParameter sqlParam3 = new SqlParameter("@adress", customer.Adress);
            SqlParameter sqlParam4 = new SqlParameter("@userId", customer.UserId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1, sqlParam2, sqlParam3, sqlParam4);           
            return status;
        }

        public int DeleteCustomer(int customerId)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = "Delete from Customer where CustomerId=@customerId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@customerId",customerId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1);
            return status;
        }

        public int UpdateCustomer(Customer customer)
        {
            
            SqlHelper sqlh = new SqlHelper(conString);
            string query = " Update Customer Set FirstName=@firstName,LastName=@lastName where CustomerId=@customerId";
            CommandType cmdtype = CommandType.Text;
            SqlParameter sqlParam1 = new SqlParameter("@firstName", customer.FirstName);
            SqlParameter sqlParam2 = new SqlParameter("@lastName", customer.LastName);
            SqlParameter sqlParam3 = new SqlParameter("@customerId", customer.CustomerId);
            int status = sqlh.ExecuteNonQuery(cmdtype, query, sqlParam1,sqlParam2, sqlParam3);
            return status;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }



       
    }
}
