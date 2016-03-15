using FinalProject.Domain.Model;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using FinalProject.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOrderDetailsService _orderServiceDetails;
        
        public ShoppingCartController(IOrderDetailsService orderServiceDetails)
        {
            _orderServiceDetails = orderServiceDetails;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            ViewBag.Total = ShoppingCart.Total;
            TempData["ShoppingCart"] = ShoppingCart;
            return View(ShoppingCart.items);
        }

        public ActionResult UpdateItemQtyInCart(FormCollection formData)
        {
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            ShoppingCart.Items[int.Parse(formData["frmIndex"])].Quantity =int.Parse(formData["item.Quantity"].ToString());
            ShoppingCart.Items[int.Parse(formData["frmIndex"])].Amount = ShoppingCart.Items[int.Parse(formData["frmIndex"])].Price * ShoppingCart.Items[int.Parse(formData["frmIndex"])].Quantity;
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart()
        {
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            if (ShoppingCart == null)
            {
                ViewBag.Message = "Cart is Empty";
            }
            else
            {
                Product p = TempData["Product"] as Product;
                OrderDetails item = new OrderDetails() { ProductId = p.ProductId, Price = p.Price, Quantity = 1, Amount=p.Price};
                ShoppingCart.Items.Add(item);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveItemFromCart(int index)
        {
            
            //Cart ShoppingCart = this.HttpContext.Session["ShoppingCart"] as Cart;  
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
                ShoppingCart.Items.RemoveAt(index);            
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartCount()
        {
            Cart ShoppingCart = Session["ShoppingCart"] as Cart;
            ViewBag.Count = ShoppingCart.items.Count;
            return PartialView("CartCount");
        }
    }
}