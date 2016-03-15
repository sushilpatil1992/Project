using FinalProject.Data.Interfaces;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        public IList<Customer> GetCutomers()
        {
            return _CustomerRepository.GetCustomers();
        }

        public Customer GetCustomerByID(int customerId)
        {
            return _CustomerRepository.GetCustomerById(customerId);
        }

        public int InsertCustomer(Customer customer)
        {
            int status = _CustomerRepository.InsertCustomer(customer);
            return status;
        }

        public int DeleteCustomer(int customerId)
        {
            int status = _CustomerRepository.DeleteCustomer(customerId);
            return status;
        }

        public int UpdateCustomer(Customer customer)
        {
            int status = _CustomerRepository.UpdateCustomer(customer);
            return status;
        }

        public void Save()
        {
            _CustomerRepository.Save();
        }

       
    }
    
}
