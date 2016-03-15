using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Domain.Model;
namespace FinalProject.Data.Interfaces
{
   public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        int InsertCustomer(Customer customer);
        int DeleteCustomer(int customerId);
        int UpdateCustomer(Customer customer);
        void Save();
    }
}
