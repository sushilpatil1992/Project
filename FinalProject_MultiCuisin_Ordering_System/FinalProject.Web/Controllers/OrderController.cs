using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using FinalProject.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FinalProject.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly IOrderDetailsService _OrderDetailsService;
        private readonly ICustomerService _CustomerService;
        public OrderController(IOrderService orderService,IOrderDetailsService orderDetailsService,ICustomerService customerService)
        {
            _OrderDetailsService = orderDetailsService;
            _OrderService = orderService;
            _CustomerService = customerService;
        }
        // GET: Order

        [Authorize]
        public ActionResult Index()
        {            
            Order order =new Order();
            order.CustomerId = _CustomerService.GetCutomers().Where(c => c.UserId == User.Identity.Name).SingleOrDefault().CustomerId;            
            order.OrderDate = System.DateTime.Now;            
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;//TempData["ShoppingCart"] as Cart;            
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            order.Items = ShoppingCart.items;
            order.Amount = ShoppingCart.Total;
            ViewBag.Total = ShoppingCart.Total;
            return View(order);
        }
        [Authorize]
        public ActionResult Checkout()
        {
            Order order = new Order();
            
            order.OrderDate = System.DateTime.Now;
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            var Items = ShoppingCart.Items;
            order.Amount = ShoppingCart.Total;            
            order.CustomerId=_CustomerService.GetCutomers().Where(c => c.UserId == User.Identity.Name).SingleOrDefault().CustomerId;
            _OrderService.InsertOrder(order);
            int orderId = _OrderService.GetOrders().Where(c => c.CustomerId == order.CustomerId).FirstOrDefault().OrderId;
            foreach (OrderDetails o in Items)
            {
                o.OrderId = orderId;
                o.Amount = o.Price * o.Quantity;
                _OrderDetailsService.InsertOrderDetails(o);
            }
            //_OrderService.InsertOrder(order);
            ShoppingCart.Items.Clear();
           
            //this.HttpContext.Session["ShoppingCart"] = ShoppingCart;
            Session["ShoppingCart"]= ShoppingCart;
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Payment()
        {
            return View();
        }

       // [Authorize(Roles="Admin")]
        public ActionResult List()
        {           
            return View(_OrderService.GetOrders());
        }
       // [Authorize(Roles = "Admin")]
        public ActionResult OrderDetails(int id)
        {
            IList<OrderDetails> oDetails = _OrderDetailsService.GetOrderDetails().Where(c => c.OrderId == id).ToList() ;
            return View(oDetails);
        }
    }
}