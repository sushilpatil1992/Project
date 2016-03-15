using FinalProject.Domain.Model;
using FinalProject.Ioc.App_Start;
using FinalProject.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FinalProject.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityWebActivator.Start();    

        }

        protected void Session_Start(Object sender,EventArgs e)
        {
                Cart theCart = new Cart();
                OrderDetails defaultItem = new OrderDetails();            
                //defaultItem.ProductId = 1;
                //defaultItem.Quantity = 1;
                //defaultItem.Price = 5000;
                //theCart.Add(defaultItem);
                this.Session.Add("ShoppingCart", theCart);
            
        }
    }

}
