using FinalProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FinalProject.Data.Repository;
using FinalProject.Service.Services;
using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
namespace FinalProject.Web.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {         

            return View(_CustomerService.GetCutomers());
        }
        [Authorize]
        public ActionResult Profile()
        {
            Customer cus=_CustomerService.GetCutomers().SingleOrDefault(c => c.UserId == User.Identity.Name);
           return View(cus);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( CustomerViewModel customerVm)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();                
                customer = copyCustomer(customerVm);
                customer.UserId = "1";
                _CustomerService.InsertCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

       

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer cus =_CustomerService.GetCustomerByID(id);
            if(cus==null)
            {
                return HttpNotFound();
            }
            CustomerViewModel customer = copyCustomer(cus);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer cus = new Customer();
                    cus = copyCustomer(customerVm);
                    cus.UserId = "1";
                    _CustomerService.UpdateCustomer(cus);
                    return RedirectToAction("Index");
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

       

        public CustomerViewModel copyCustomer(Customer customer)
        {
            CustomerViewModel customerVm=new CustomerViewModel();
            customerVm.FirstName = customer.FirstName;
            customerVm.LastName = customer.LastName;
            customerVm.Adress = customer.Adress;
            customerVm.CustomerId = customer.CustomerId;
            //c.UserId = User.Identity.GetUserId();
            //c.UserId = customer.ApplicationUserId;
            return customerVm;
        }
        public Customer copyCustomer(CustomerViewModel customer)
        {
            Customer customerVm = new Customer();
            customerVm.FirstName = customer.FirstName;
            customerVm.LastName = customer.LastName;
            customerVm.Adress = customer.Adress;
            customerVm.CustomerId = customer.CustomerId;
            //c.UserId = User.Identity.GetUserId();
            //c.UserId = customer.ApplicationUserId;
            return customerVm;
        }

        //[ChildActionOnly]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.UserId = User.Identity.Name;
            int status = _CustomerService.InsertCustomer(customer);
            return RedirectToAction("index", "Home");
        }
    }
}
