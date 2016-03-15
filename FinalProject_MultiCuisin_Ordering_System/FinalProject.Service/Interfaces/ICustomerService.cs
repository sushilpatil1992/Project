using FinalProject.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Interfaces
{
    public interface ICustomerService
    {
        IList<Customer> GetCutomers();
        Customer GetCustomerByID(int customerId);
        int InsertCustomer(Customer customer);
        int DeleteCustomer(int customerId);
        int UpdateCustomer(Customer customer);
        void Save();
    }
}
